using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class Joueur
    {
        #region "Propriétés privées"
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, CaracteristiqueJoueur> _caracs { get; set; }

        protected string _nom;

        protected List<Deck> _decks ;

        protected InventaireDeCarte _cartesEnMain;

        #endregion

        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NomCarac"></param>
        /// <returns></returns>
        public decimal this[string nomCarac]
        {
            get
            {
                return _caracs[nomCarac].valeurCourante;
            }
        }

        public string nom
        {
            get
            {
                return _nom;
            }
        }

        public int tailleTerrain
        {
            get
            {
                // Prévoir un calcul de la mort
                return 6;
            }
        }

        public Deck deckActif
        {
            get
            {
                return _decks[0] ;
            }
        }
        #endregion


        #region "constructeur"
        /// <summary>
        /// 
        /// </summary>
        public Joueur()
        {
            _cartesEnMain = new InventaireDeCarte();
        }
        #endregion

        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"
        public Carte piocherCartes(int nbCarte = 1)
        {
            Carte cartePiochee = null;
            for (int i = 0; i < nbCarte; i++)
            {
                cartePiochee = deckActif.PrendreProchaineCarte();
                _cartesEnMain.ajouterCarte(cartePiochee);
            }
            return cartePiochee;
        }

        public void appliquerModificateur(Dictionary<string, decimal> modificateurs)
        {
        }
        #endregion

    }
}
