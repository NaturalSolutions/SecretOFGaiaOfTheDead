using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class Plateau
    {


        #region "Propriétés privées"
        /// <summary>
        /// 
        /// </summary>
        protected Terrain _terrainsJoueur1;
        /// <summary>
        /// 
        /// </summary>
        protected Terrain _terrainsJoueur2;
        #endregion


        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        public  Terrain terrainsJoueur1 {
            get
            {
                return _terrainsJoueur1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Terrain terrainsJoueur2
        {
            get
            {
                return _terrainsJoueur2;
            }
        }

        #endregion

        #region "Constructeurs"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="curJoueur1"></param>
        /// <param name="curJoueur2"></param>
        public Plateau(Joueur curJoueur1,Joueur curJoueur2)
        {
            _terrainsJoueur1 = new Terrain(curJoueur1.tailleTerrain);
            _terrainsJoueur2 = new Terrain(curJoueur2.tailleTerrain);
        }
        #endregion



        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"
        

        #endregion

    }
}






