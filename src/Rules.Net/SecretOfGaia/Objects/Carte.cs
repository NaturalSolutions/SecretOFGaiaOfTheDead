using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public enum TypeCarte
    {
        Instantanee = 1,
        Permanente = 2,
        Retarde = 4
    }

    /// <summary>
    /// 
    /// </summary>
    public class Carte
    {


        #region "Propriétés privées"
        /// <summary>
        /// 
        /// </summary>
        protected string _nom;

        /// <summary>
        /// 
        /// </summary>
        protected string _description;

        /// <summary>
        /// 
        /// </summary>
        protected int _attaque;

        /// <summary>
        /// 
        /// </summary>
        protected int _soin;

        protected int _action;

        /// <summary>
        /// 
        /// </summary>
        protected TypeCarte _typeCarte;

        /// <summary>
        /// Valeur Naturelle de la carte 
        /// </summary>
        protected int _valeurCarte;


        protected Dictionary<string, decimal> _modificateurJoueur;
        protected Dictionary<string, decimal> _modificateurAdversaire;

        #endregion


        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        public string nom
        {
            get { return this._nom; }
        }

        public string description
        {
            get
            {
                return _description;
            }
        }

        public TypeCarte TypeCarte
        {
            get { return this._typeCarte; }
        }

        public int attaque
        {
            get
            {
                return _attaque;
            }
        }

        public int soin
        {
            get
            {
                return _soin;
            }
        }

        public int action
        {
            get
            {
                return _action;
            }
        }

        public int valeurCarte
        {
            get
            {
                return _valeurCarte;
            }
        }

        public Dictionary<string, decimal> modificateurJoueur
        {
            get
            {
                return _modificateurJoueur;
            }
        }

        public Dictionary<string, decimal> modificateurAdversaire
        {
            get
            {
                return _modificateurAdversaire;
            }
        }


        #endregion

        #region "Constructeurs"

        /// <summary>
        /// 
        /// </summary>
        public Carte(string curNom, TypeCarte curTypeCarte, int curAttaque, int curSoin, int curAction, int curValeur = -1, Dictionary<string, decimal> curmodificateurJoueur = null, Dictionary<string, decimal> curmodificateurAdversaire = null)
        {
            this._nom = curNom;
            this._typeCarte = curTypeCarte;
            this._attaque = curAttaque;
            this._soin = curSoin;
            _action = curAction;
            if (curValeur == -1)
            {
                _valeurCarte = this._action;
            }
            else
            {
                _valeurCarte = curValeur;
            }
            if (curmodificateurJoueur == null)
            {
                _modificateurJoueur = new Dictionary<string, decimal>();

            }
            else
            {
                _modificateurJoueur = curmodificateurJoueur;
            }
            if (curmodificateurAdversaire == null)
            {
                _modificateurAdversaire = new Dictionary<string, decimal>();

            }
            else
            {
                _modificateurAdversaire = curmodificateurAdversaire;
            }







        }
        #endregion


        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"

        #endregion

    }
}
