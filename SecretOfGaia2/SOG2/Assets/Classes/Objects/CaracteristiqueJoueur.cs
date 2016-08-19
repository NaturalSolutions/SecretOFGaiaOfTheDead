using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecretOfGaia
{
    /// <summary>
    /// 
    /// </summary>
    public class CaracteristiqueJoueur
    {
        #region "Propriétés privées"
        /// <summary>
        /// 
        /// </summary>
        protected decimal _valeurMax;
        /// <summary>
        /// 
        /// </summary>
        protected decimal _valeurCourante;
        #endregion


        #region "Proprités publiques"
        /// <summary>
        /// 
        /// </summary>
        public decimal valeurMax
        {
            get { return this._valeurMax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal valeurCourante
        {
            get { return this._valeurCourante; }
        }

        #endregion

        #region "constructeur"
        /// <summary>
        /// 
        /// </summary>
        public CaracteristiqueJoueur(decimal curValeurMax = 0)
        {
            _valeurMax = curValeurMax;
            _valeurCourante = curValeurMax;
        }
        #endregion


        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"
        public decimal appliquerModification(decimal modificateur, bool surValeurMax = false, bool valeurRelative = true)
        {
            if (!surValeurMax)
            {
                if (valeurRelative)
                {
                    this._valeurCourante = Math.Min(this._valeurCourante + modificateur, this._valeurMax);
                }
                else
                {
                    this._valeurCourante = Math.Min(modificateur, this._valeurMax);
                }
            }
            else
            {

                if (valeurRelative)
                {
                    this._valeurMax += modificateur;
                    this._valeurCourante += modificateur;
                }
                else
                {
                    this._valeurMax = modificateur;
                    this._valeurCourante = modificateur;
                }

            }
            return this._valeurCourante;
        }
        #endregion

    }
}
