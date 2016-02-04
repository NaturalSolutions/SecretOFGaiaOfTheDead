using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class InventaireDeCarte
    {


        #region "Propriétés privées"
        protected List<Carte> _cartes;
        #endregion


        #region "Proprités publiques"


        #endregion

        #region "Constructeurs"
        /// <summary>
        /// 
        /// </summary>
        public InventaireDeCarte()
        {
        }
        #endregion


        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumCarte"></param>
        /// <returns></returns>
        public Carte this[int NumCarte] {
            get {
                return _cartes[NumCarte] ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NomCarte"></param>
        /// <returns></returns>
        public Carte this[string NomCarte]
        {
            get
            {
                return _cartes.Where(s=>s.Nom.ToLower() == NomCarte.ToLower()).FirstOrDefault() ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Carte ProchaineCarte
        {
            get
            {
                return this._cartes[0];
            }
        }
        #endregion

    }
}
