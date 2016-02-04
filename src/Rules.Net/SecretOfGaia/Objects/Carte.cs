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
        Permenanete = 2,
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
        protected string _Nom;
        protected TypeCarte _TypeCarte;
        protected int _ValeurCarte;
        #endregion


        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        public string Nom
        {
            get { return this._Nom; }
        }

        public TypeCarte TypeCarte
        {
            get { return this._TypeCarte; }
        }


        public int ValeurCarte
        {
            get
            {
                return ValeurCarte;
            }
        }
        #endregion

        #region "Constructeurs"

        /// <summary>
        /// 
        /// </summary>
        public Carte()
        {
        }
        #endregion


        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"

        #endregion

    }
}
