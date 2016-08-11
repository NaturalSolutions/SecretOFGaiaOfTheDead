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

        protected List<Deck> _decks;

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
                return _decks[0];
            }
        }

        public Dictionary<string, CaracteristiqueJoueur> caracs
        {
            get
            {
                return (from x in _caracs
                        select x).ToDictionary(x => x.Key, x => x.Value);
            }
        }
        public List<Deck> decks
        {
            get
            {
                return _decks.ToList();
            }
        }

        public InventaireDeCarte cartesEnMain
        {
            get
            {
                return _cartesEnMain;
            }
        }


        public Dictionary<string, decimal> caracMax
        {
            get
            {
                return _caracs.ToDictionary(s => s.Key, s => s.Value.valeurMax, StringComparer.CurrentCultureIgnoreCase);
            }
        }
        #endregion


        #region "constructeur"
        /// <summary>
        /// 
        /// </summary>
        public Joueur(string curNom, List<Deck> curDecks = null, Dictionary<string, CaracteristiqueJoueur> curCaracs = null)
        {
            _cartesEnMain = new InventaireDeCarte();
            _nom = curNom;
            _decks = curDecks;
            if (_decks == null)
            {
                _decks = new List<Deck>();
            }
            _caracs = new Dictionary<string, CaracteristiqueJoueur>(StringComparer.CurrentCultureIgnoreCase);
            if (curCaracs != null)
            {
                curCaracs.Keys.ToList().ForEach(s => _caracs.Add(s, curCaracs[s]));
            }

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

        public void appliquerModificateur(Dictionary<string, decimal> modificateurs, bool surValeurMax = false, bool valeurRelative = true)
        {

            foreach (string carac in modificateurs.Keys)
            {
                if (!_caracs.ContainsKey(carac))
                {
                    _caracs[carac] = new CaracteristiqueJoueur();
                    _caracs[carac].appliquerModification(modificateurs[carac], surValeurMax: true, valeurRelative: valeurRelative);
                }
                else
                {
                    _caracs[carac].appliquerModification(modificateurs[carac], surValeurMax, valeurRelative);
                }
            }
        }
        #endregion

    }
}
