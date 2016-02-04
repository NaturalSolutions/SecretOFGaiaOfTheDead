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

        #endregion


        #region "Proprités publiques"
        public int ValeurDeck { 
            get {
                return this._cartes.Select(s => s.ValeurCarte).Sum();
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
