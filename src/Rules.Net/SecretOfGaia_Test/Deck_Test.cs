using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretOfGaia;

namespace SecretOfGaia_Test
{
    [TestClass]
    public class Deck_Test
    {



        [TestMethod]
        public void TestCreationDeDeckEtAjoutUneCarte()
        {
            Deck MonDeck = new Deck();
            Assert.AreEqual(0,MonDeck.Count,"Création Deck pas vide") ;
            Carte maCarte = new Carte("Test1",TypeCarte.Instantanee,1,1,12 ) ;
            MonDeck.ajouterCarte(maCarte);
            Assert.AreEqual(1,MonDeck.Count,"Ajout de Carte NOK") ;
            Assert.AreEqual(12, MonDeck.valeurDeck, "Valeur Deck NOK avec 1 élément");
            Assert.AreEqual(maCarte, MonDeck.prochaineCarte,"Prochaine Carte NOK ");
        }

        [TestMethod]
        public void TestCreationDeDeckEtAjoutPlusieursCarte()
        {
            Deck MonDeck = new Deck();
            Carte maCarte1 = new Carte("Carte1", TypeCarte.Instantanee, 1, 1, 12);
            MonDeck.ajouterCarte(maCarte1);
            Carte maCarte2 = new Carte("Carte2", TypeCarte.Instantanee, 1, 1, 7);
            MonDeck.ajouterCarte(maCarte2);
            Assert.AreEqual(2, MonDeck.Count, "Ajout de 2 Cartes NOK");
            Assert.AreEqual(19, MonDeck.valeurDeck, "Valeur Deck NOK avec 2 éléments");
            Assert.AreEqual(maCarte1, MonDeck.prochaineCarte, "Prochaine Carte NOK avec 2 éléements ");


        }


    }
}
