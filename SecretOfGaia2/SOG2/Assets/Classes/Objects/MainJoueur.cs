using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class Deck:InventaireDeCarte
    {


        #region "Propriétés privées"
        protected string _nom;
        #endregion


        #region "Proprités publiques"
        public int valeurDeck { 
            get {
                return this._cartes.Select(s => s.Value.valeurCarte).Sum();
            } 
        }

        public string nom
        {
            get
            {
                
                return _nom;
            }
        }
        #endregion

        #region "Constructeurs"

        #endregion


        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"

        #endregion

    }
}
