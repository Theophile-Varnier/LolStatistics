﻿
namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Interface de base des repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {

        /// <summary>
        /// Insertion d'un objet
        /// </summary>
        /// <param name="t">Objet à insérer</param>
        bool Insert(T t);

        /// <summary>
        /// Récupération en base depuis un id
        /// </summary>
        /// <param name="id">L'id de l'objet à récupérer</param>
        /// <returns></returns>
        T GetById(long id);
    }
}
