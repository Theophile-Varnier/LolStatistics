using LolStatistics.DataAccess.Exceptions;
using LolStatistics.DataAccess.Extensions;
using LolStatistics.Model.Teams;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace LolStatistics.DataAccess.Dao
{
    public class RankedTeamDao: BaseDao<RankedTeam>
    {
        public RankedTeam GetByName(string name, DbConnection conn)
        {
            const string cmd = "SELECT TEAM_NAME, TEAM_ID FROM RANKED_TEAM WHERE TEAM_NAME = @teamName";

            IList<RankedTeam> res = ExecuteReader(cmd, conn, name, (c, o) => c.AddWithValue("@teamName", o));
            if (res.Count != 1)
            {
                throw new DaoException("Etrange");
            }

            return res.First();
        }

        /// <summary>
        /// Récupère les ids de toutes les parties d'une team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IList<long> GetHistory(long teamId, DbConnection conn)
        {
            IList<long> res = new List<long>();
            using (Command cmd = new Command("SELECT MATCH_ID FROM RANKED_TEAM_MATCH WHERE TEAM_ID = @teamId"))
            {
                cmd.Connection = conn;

                cmd.Prepare();

                cmd.AddWithValue("@teamId", teamId);

                // Exécution
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            res.Add(reader.GetInt64("MATCH_ID"));
                        }
                    }
                }

                return res;
            }
        } 

        public override RankedTeam RecordToDto(DbDataReader reader)
        {
            RankedTeam res = new RankedTeam
            {
                Name = reader.GetString("TEAM_NAME"),
                Id = reader.GetInt64("TEAM_ID")
            };
            return res;
        }
    }
}
