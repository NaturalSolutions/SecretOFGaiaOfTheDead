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
        protected Dictionary<int,Carte> _cartes;
        #endregion


        #region "Proprités publiques"


        #endregion

        #region "Constructeurs"
        /// <summary>
        /// 
        /// </summary>
        public InventaireDeCarte()
        {
            _cartes = new Dictionary<int, Carte>();
        }
        #endregion


        #region "Methodes privées"

        #endregion


        #region "Méthode publiques"

        public int Count
        {
            get
            {
                return _cartes.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NumCarte"></param>
        /// <returns></returns>
        public virtual Carte this[int position] {
            get {
                return _cartes[position] ;
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
                return _cartes.Select(s=>s.Value).Where(s=>s.nom.ToLower() == NomCarte.ToLower()).FirstOrDefault() ;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Carte prochaineCarte
        {
            get
            {
                if (_cartes.Count == 0)
                {
                    return null;
                }
                else
                {
                    return this._cartes[this._cartes.Keys.Min()];
                }
            }
        }

        public virtual bool ajouterCarte(Carte curcarte)
        {
            _cartes.Add(_cartes.Keys.DefaultIfEmpty(0).Max() + 1, curcarte);
            return true;
        }

        public virtual bool ajouterCarte(Carte curcarte,int position = - 1,bool remplaceExistante = true)
        {
            if (position == -1)
            {
                position = _cartes.Keys.DefaultIfEmpty(0).Max() + 1 ;
            }
            if (_cartes.ContainsKey(position))
            {
                if (remplaceExistante)
                {
                    _cartes.Remove(position);
                }
                else
                {
                    return false;
                }
            }
            _cartes.Add(position, curcarte);
            return true;
        }


        public virtual bool enleverCarte(int position)
        {
            if (_cartes.ContainsKey(position))
            {
                _cartes.Remove(position);
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

    }
}
