using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretOfGaia;

namespace SecretOfGaia_Test
{
    [TestClass]
    public class PoseJoueur_Test
    {
        [TestMethod]
        public void TestCreationPoseJoueur()
        {
            PoseJoueur curPose = new PoseJoueur(1);
            Assert.AreEqual(1, curPose.taille);
            Assert.AreEqual(0, curPose.Count,"Consctruteur PoseJoueur COunt NOK");
        }

        [TestMethod]
        public void TestAjoutCarteEnTrop()
        {
            PoseJoueur curPose = new PoseJoueur(2);
            Carte maCarte1 = new Carte("Carte1", TypeCarte.Instantanee, 1, 1, 12);
            bool AjoutOK =  curPose.ajouterCarte(maCarte1);
            Carte maCarte2 = new Carte("Carte2", TypeCarte.Instantanee, 1, 1, 7);
            AjoutOK = curPose.ajouterCarte(maCarte2);
            Assert.AreEqual(true, AjoutOK, "Ajout Carte autorise NOK sur retour ajouterCarte");
            Assert.AreEqual(2, curPose.Count, "Ajout de 2 Cartes NOK");
            Assert.AreEqual(maCarte1, curPose.prochaineCarte, "Prochaine Carte NOK avec 2 éléements ");
            Carte maCarte3 = new Carte("Carte3", TypeCarte.Instantanee, 1, 1, 7);
            AjoutOK = curPose.ajouterCarte(maCarte3);
            Assert.AreEqual(false, AjoutOK, "Ajout Carte Interdite NOK sur retour ajouterCarte");
            Assert.AreEqual(2, curPose.Count, "Ajout de 2 Cartes NOK sur Count");

        }

        [TestMethod]
        public void TestAjoutCarteSuperposée()
        {
            PoseJoueur curPose = new PoseJoueur(2);
            Carte maCarte1 = new Carte("Carte1", TypeCarte.Instantanee, 1, 1, 12);
            bool AjoutOK = curPose.ajouterCarte(maCarte1);
            Carte maCarte2 = new Carte("Carte2", TypeCarte.Instantanee, 1, 1, 7);
            AjoutOK = curPose.poserSur(1,maCarte2);
            Assert.AreEqual(1, curPose.Count, "Ajout de Cartes dessus NOK");
            Assert.AreEqual(maCarte2, curPose[1], "Ajout de Cartes dessus NOK");

        }


        [TestMethod]
        public void TestElenverCarteSuperposée()
        {
            PoseJoueur curPose = new PoseJoueur(2);
            Carte maCarte1 = new Carte("Carte1", TypeCarte.Instantanee, 1, 1, 12);
            bool AjoutOK = curPose.ajouterCarte(maCarte1);
            Carte maCarte2 = new Carte("Carte2", TypeCarte.Instantanee, 1, 1, 7);
            AjoutOK = curPose.poserSur(1, maCarte2);
            curPose.enleverCarte(1);
            Assert.AreEqual(1, curPose.Count, "Enlever Carte dessus Count NOK");
            Assert.AreEqual(maCarte1, curPose[1], "Enlever Cartes dessus Carte NOK");
        }

        [TestMethod]
        public void TestElenverCarteduDessousAvecSuperposition()
        {
            PoseJoueur curPose = new PoseJoueur(2);
            Carte maCarte1 = new Carte("Carte1", TypeCarte.Instantanee, 1, 1, 12);
            bool AjoutOK = curPose.ajouterCarte(maCarte1);
            Carte maCarte2 = new Carte("Carte2", TypeCarte.Instantanee, 1, 1, 7);
            AjoutOK = curPose.poserSur(1, maCarte2);
            curPose.enleverCarte(1,true);
            Assert.AreEqual(0, curPose.Count, "Enlever Carte dessous Count NOK");
        }
    }
}
