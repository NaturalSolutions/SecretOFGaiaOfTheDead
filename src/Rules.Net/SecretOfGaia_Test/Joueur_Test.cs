using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretOfGaia;
using System.Collections.Generic;

namespace SecretOfGaia_Test
{
    [TestClass]
    public class Joueur_Test
    {
        [TestMethod]
        public void TestCreationJoueurVide()
        {
            Joueur MonJoueur = new Joueur("Joueur1");
            Assert.AreEqual("Joueur1",MonJoueur.nom, " COnstructeur Nom joueur NOK");
            Assert.AreEqual(0, MonJoueur.decks.Count, " COnstructeur nb desck NOK");
            Assert.AreEqual(0, MonJoueur.caracs.Count, " COnstructeur nb carac NOK");
        }

        [TestMethod]
        public void TestCreationJoueurAvecCarac()
        {
            Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(5)}
                ,{"PV",new CaracteristiqueJoueur(15)}
            };
            Joueur MonJoueur = new Joueur("JoueurTest1",curCaracs: caracs);
            Assert.AreEqual("JoueurTest1", MonJoueur.nom, " Constructeur Nom joueur NOK");
            Assert.AreEqual(0, MonJoueur.decks.Count, " COnstructeur Nom joueur NOK");
            Assert.AreEqual(2, MonJoueur.caracs.Count, " COnstructeur Nom joueur NOK");
            Assert.AreEqual(5, MonJoueur["force"], " COnstructeur Valeur force NOK");
            Assert.AreEqual(15, MonJoueur["PV"], " COnstructeur Valeur force NOK");
        }

        [TestMethod]
        public void TestJoueurModifCaracRelative()
        {
            Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(5)}
                ,{"PV",new CaracteristiqueJoueur(15)}
            };
            Joueur MonJoueur = new Joueur("JoueurTest1", curCaracs: caracs);
            Assert.AreEqual(5, MonJoueur["force"], " COnstructeur Valeur force NOK");
            Assert.AreEqual(15, MonJoueur["PV"], " COnstructeur Valeur force NOK");

            Dictionary<string, decimal> modif = new Dictionary<string, decimal> {
                {"Force",5}
                ,{"PV",-5}
            };

            MonJoueur.appliquerModificateur(modif);

            Assert.AreEqual(10, MonJoueur["force"], " modif force NOK");
            Assert.AreEqual(10, MonJoueur["PV"], " modif PV NOK");

            Assert.AreEqual(5, MonJoueur.caracMax["force"], " modif force valeur Max NOK");
            Assert.AreEqual(15, MonJoueur.caracMax["PV"], " modif PV NOK valeur Max NOK");


        }


        [TestMethod]
        public void TestJoueurModifCarac()
        {
            Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(5)}
                ,{"PV",new CaracteristiqueJoueur(15)}
            };
            Joueur MonJoueur = new Joueur("JoueurTest1", curCaracs: caracs);
            Assert.AreEqual(5, MonJoueur["force"], " COnstructeur Valeur force NOK");
            Assert.AreEqual(15, MonJoueur["PV"], " COnstructeur Valeur force NOK");

            Dictionary<string, decimal> modif = new Dictionary<string, decimal> {
                {"Force",3}
                ,{"PV",65}
            };

            MonJoueur.appliquerModificateur(modif,valeurRelative:false);

            Assert.AreEqual(3, MonJoueur["force"], " modif force NOK");
            Assert.AreEqual(65, MonJoueur["PV"], " modif PV NOK");

            Assert.AreEqual(5, MonJoueur.caracMax["force"], " modif force valeur Max NOK");
            Assert.AreEqual(15, MonJoueur.caracMax["PV"], " modif PV NOK valeur Max NOK");


        }

        [TestMethod]
        public void TestJoueurCreationCarac()
        {
            Dictionary<string, CaracteristiqueJoueur> caracs = new Dictionary<string, CaracteristiqueJoueur> {
                {"Force",new CaracteristiqueJoueur(5)}
                ,{"PV",new CaracteristiqueJoueur(15)}
            };
            Joueur MonJoueur = new Joueur("JoueurTest1", curCaracs: caracs);

            Dictionary<string, decimal> modif = new Dictionary<string, decimal> {
                {"Action",8}
            };
            MonJoueur.appliquerModificateur(modif);
            Assert.AreEqual(8, MonJoueur["Action"], " Création action NOK");
        }


    }
}
