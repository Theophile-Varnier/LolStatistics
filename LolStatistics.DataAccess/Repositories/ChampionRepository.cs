using LolStatistics.DataAccess.Dao;
using LolStatistics.DataAccess.Exceptions;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Static;
using System.Collections.Generic;
using System.Data.Common;

namespace LolStatistics.DataAccess.Repositories
{
    public class ChampionRepository: IRepository<Champion>
    {
        ChampionDao championDao = new ChampionDao();

        /// <summary>
        /// 
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
        /// 
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
        /// 
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
