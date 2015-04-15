﻿using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Exceptions;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Static;
using System.Collections.Generic;
using System.Data.Common;

namespace LolStatistics.DataAccess.Repositories
{
    /// <summary>
    /// Repository associé aux champions
    /// </summary>
    public class ChampionRepository: IRepository<Champion>
    {
        ChampionDao championDao = new ChampionDao();

        /// <summary>
        /// Insert un champion en base
        /// </summary>
        /// <param name="t"></param>
        public void Insert(Champion t)
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                using (DbTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        conn.Open();
                        championDao.Insert(t, conn, tran);
                        tran.Commit();
                    }
                    catch (DaoException e)
                    {
                        tran.Rollback();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Récupère un champion à partir de son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Champion GetById(string id)
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    return championDao.GetById(id, conn);
                }
                catch (DaoException e)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Récupère la liste de tous les champions
        /// </summary>
        /// <returns></returns>
        public List<Champion> GetAllChampions()
        {
            using (DbConnection conn = Command.GetConnexion())
            {
                try
                {
                    conn.Open();
                    return championDao.GetAllChampions(conn);
                }
                catch (DaoException e)
                {
                    return new List<Champion>();
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
