using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretOfGaia;
using System.Collections.Generic;

namespace SecretOfGaia_Test
{
    [TestClass]
    public class RuleController_Test
    {

        public Carte getCarte(string NomCarte)
        {
            switch (NomCarte)
            {
                case "Guêpe":
                    return new Carte("Guêpe", TypeCarte.Instantanee, 5, 0, 5);
                case "Mante religieuse":
                    return new Carte("Mante religieuse", TypeCarte.Instantanee, 3, 0, 2);
                case "Goéland leucophée":
                    return new Carte("Goéland leucophée", TypeCarte.Instantanee, 4, 0, 2);
                case "Immortelle des dunes":
                    Dictionary<string, decimal> modifJoueur = new Dictionary<string, decimal>{
                        {"PV",1},
                    };
                    return new Carte("Immortelle des dunes", TypeCarte.Permanente, 4, 0,4,curmodificateurJoueur:modifJoueur);
                case "Figuier de Barbarie":
                    return new Carte("Figuier de Barbarie", TypeCarte.Retarde,0, 3, 3);
                default:
                    return new Carte("Guêpe", TypeCarte.Instantanee, 5, 0, 4);
            }
        }


        public Deck construireUnDeck(Dictionary<string, int> ListeCarte)
        {
            Deck monDeck = new Deck();
            foreach (string clef in ListeCarte.Keys)
            {
                for (int i = 0; i < ListeCarte[clef]; i++)
                {
                    monDeck.ajouterCarte(getCarte(clef));
                }
            }
            return monDeck;

        }
        public Joueur obtenirJoueur1()
        {

            Deck DeckJoueur1 = construireUnDeck(new Dictionary<string, int>{
                {"Guêpe",5},
                {"Mante religieuse",10},
                {"Goéland leucophée",3}
            });



            Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(5)}
                ,{"PV",new CaracteristiqueJoueur(15)}
            };
            Joueur MonJoueur1 = new Joueur("JoueurTest1", curCaracs: caracs, curDecks: new List<Deck> { DeckJoueur1 });
            return MonJoueur1;
        }

        public Joueur obtenirJoueur2()
        {
            Deck DeckJoueur2 = construireUnDeck(new Dictionary<string, int>{
                {"Guêpe",10},
                {"Mante religieuse",5},
                {"Goéland leucophée",5}
            });

            Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(8)}
                ,{"PV",new CaracteristiqueJoueur(22)}
            };
            Joueur MonJoueur = new Joueur("JoueurTest1", curCaracs: caracs, curDecks: new List<Deck> { DeckJoueur2 });
            return MonJoueur;
        }

        [TestMethod]
        public void TestDebutDuJeu()
        {
            RuleController MonControlleur = new RuleController();
            MonControlleur.demarerDuel(obtenirJoueur1(), obtenirJoueur2());
            Assert.AreEqual(1, MonControlleur.numTour, "Num tour NOK");
            Assert.AreEqual(3, MonControlleur.nbAction, "NbAction tour NOK");
            Assert.AreEqual(4, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 NOk");
            Assert.AreEqual(4, MonControlleur.joueur2.cartesEnMain.Count, "Nb cartes en mains joueur 2 NOk");

        }



        [TestMethod]
        public void TestFinTour()
        {
            RuleController MonControlleur = new RuleController();
            MonControlleur.demarerDuel(obtenirJoueur1(), obtenirJoueur2());
            MonControlleur.finTourJoueur1();
            MonControlleur.finTourJoueur2();
            Assert.AreEqual(2, MonControlleur.numTour, "Num tour NOK");
            Assert.AreEqual(4, MonControlleur.nbAction, "NbAction tour NOK");
            Assert.AreEqual(5, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 NOk");
            Assert.AreEqual(5, MonControlleur.joueur2.cartesEnMain.Count, "Nb cartes en mains joueur 2 NOk");

        }


        [TestMethod]
        public void TestJouerCartePossible()
        {
            RuleController MonControlleur = new RuleController();
            MonControlleur.demarerDuel(obtenirJoueur1(), obtenirJoueur2());
            decimal actionAvantCarte = MonControlleur.joueur1["actions"];
            decimal PVJoueur2 = MonControlleur.joueur2["PV"];
            MonControlleur.joueur1.cartesEnMain.ajouterCarte(getCarte("Mante religieuse")) ;
            Assert.AreEqual(5, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 NOk");
            Carte carteJouee = MonControlleur.jouerUneCarteDepuisLaMain("Mante religieuse");

            Assert.AreEqual(actionAvantCarte - carteJouee.action, MonControlleur.joueur1["actions"], "Nb action après jouer une carte NOK");
            Assert.AreEqual(4, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 après jouer une carte NOk");
            Assert.AreEqual(PVJoueur2 - carteJouee.attaque, MonControlleur.joueur2["PV"], "PV joueur 2  après jouer une carte NOk");


        }


        [TestMethod]
        public void TestJouerCarteImpossible()
        {
            RuleController MonControlleur = new RuleController();
            MonControlleur.demarerDuel(obtenirJoueur1(), obtenirJoueur2());
            decimal actionAvantCarte = MonControlleur.joueur1["actions"];
            decimal PVJoueur2 = MonControlleur.joueur2["PV"];
            MonControlleur.joueur1.cartesEnMain.ajouterCarte(getCarte("Guêpe"));
            Assert.AreEqual(5, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 NOk");
            Carte carteJouee = MonControlleur.jouerUneCarteDepuisLaMain("Guêpe");


            Assert.AreEqual(actionAvantCarte, MonControlleur.joueur1["actions"], "Nb action après jouer une carte NOK");
            Assert.AreEqual(5, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 après jouer une carte NOk");
            Assert.AreEqual(PVJoueur2,MonControlleur.joueur2["PV"], "PV joueur 2  après jouer une carte NOk");
        }



        [TestMethod]
        public void TestDebutTourCartePermSoin()
        {
            RuleController MonControlleur = new RuleController();
            MonControlleur.demarerDuel(obtenirJoueur1(), obtenirJoueur2());
            decimal actionAvantCarte = MonControlleur.joueur1["actions"];
            decimal PVJoueur2 = MonControlleur.joueur2["PV"];
            MonControlleur.joueur1.cartesEnMain.ajouterCarte(getCarte("Mante religieuse"));
            Assert.AreEqual(5, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 NOk");
            Carte carteJouee = MonControlleur.jouerUneCarteDepuisLaMain("Mante religieuse");
            Assert.AreEqual(PVJoueur2-carteJouee.attaque, MonControlleur.joueur2["PV"], "PV joueur 2  après jouer une carte NOk");
            MonControlleur.plateau.terrainsJoueur2.ajouterCarte(getCarte("Immortelle des dunes"));
            MonControlleur.finTourJoueur1();
            Assert.AreEqual(PVJoueur2 - carteJouee.attaque+1, MonControlleur.joueur2["PV"], "PV après immortelle des dunes NOK");

            
        }


        [TestMethod]
        public void TestCarteRetardée()
        {
            RuleController MonControlleur = new RuleController();
            MonControlleur.demarerDuel(obtenirJoueur1(), obtenirJoueur2());
            decimal actionAvantCarte = MonControlleur.joueur1["actions"];
            int PaceLibreTerrainJoueur1 = MonControlleur.plateau.terrainsJoueur1.positionsLibres.Count;
            MonControlleur.joueur1.cartesEnMain.ajouterCarte(getCarte("Figuier de Barbarie"));
            Assert.AreEqual(5, MonControlleur.joueur1.cartesEnMain.Count, "Nb cartes en mains joueur 1 NOk");
            Carte carteJouee = MonControlleur.jouerUneCarteDepuisLaMain("Figuier de Barbarie");
            Assert.AreEqual(actionAvantCarte-3,MonControlleur.joueur1["actions"],"Nb action après carte retadrée NOK");
            Assert.AreEqual(PaceLibreTerrainJoueur1 - 1, MonControlleur.plateau.terrainsJoueur1.positionsLibres.Count, "Nb place libre joueur 1 NOK");

        }

    }
}
