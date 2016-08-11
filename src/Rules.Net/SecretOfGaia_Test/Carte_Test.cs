using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretOfGaia;
using System.Collections.Generic;

namespace SecretOfGaia_Test
{
    [TestClass]
    public class Carte_Test
    {
        [TestMethod]
        public void TestCarteSansValeur()
        {
            Carte maCarte = new Carte("Test1", TypeCarte.Instantanee, 10, 16, 148);
            Assert.AreEqual(TypeCarte.Instantanee, maCarte.TypeCarte, "Constructeur: Type Carte NOK");
            Assert.AreEqual(10, maCarte.attaque, "Constructeur: Attaque  NOK");
            Assert.AreEqual(16, maCarte.soin, "Constructeur: Soin NOK");
            Assert.AreEqual(148, maCarte.action, "Constructeur: Action NOK");
            Assert.AreEqual(148, maCarte.valeurCarte, "Constructeur: Valeur Carte par défaut NOK");
            Assert.AreEqual(0, maCarte.modificateurJoueur.Count, "Constructeur:  Total modificateur NOK");
            Assert.AreEqual(0, maCarte.modificateurAdversaire.Count, "Constructeur:  Total modificateur NOK");
        }

        [TestMethod]
        public void TestCarteAvecValeur()
        {
            Carte maCarte = new Carte("Test1", TypeCarte.Instantanee, 1, 1, 1,2);

            Assert.AreEqual(2, maCarte.valeurCarte, "Constructeur:  Valeur Carte explicite NOK");
        }

        /*
        [TestMethod]
        public void TestCarteAvecModificateurJoueur()
        {
            Dictionary<string, decimal> ModifJouer = new Dictionary<string, decimal> {
                 {"force",1},
                 {"force",2}
             };
            Carte maCarte = new Carte("Test1", TypeCarte.Instantanee, 1, 1, 1, 2, ModifJouer);

            Assert.AreEqual(2, maCarte.valeurCarte, "Constructeur:  Valeur Carte explicite NOK");
            Assert.AreEqual(3, maCarte.modificateurJoueur["force"], "Constructeur:  Total modificateur NOK");
        }*/

    }
}
