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
        protected Dictionary<string, CaracteristiqueJoueur> Caracs { get; set; }

        
        
        #endregion

        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NomCarac"></param>
        /// <returns></returns>
        public decimal this[string NomCarac]
        {
            get
            {
                return Caracs[NomCarac].ValeurCourante;
            }
        }
        #endregion


        #region "constructeur"
        /// <summary>
        /// 
        /// </summary>
        public Joueur()
        {
        }
        #endregion

        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"

        #endregion

    }
}
