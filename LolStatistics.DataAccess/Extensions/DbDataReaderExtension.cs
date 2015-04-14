using System.Data.Common;

namespace LolStatistics.DataAccess.Extensions
{
    /// <summary>
    /// Méthode d'extension des DataReader
    /// </summary>
    public static class DbDataReaderExtension
    {
        /// <summary>
        /// Récupère un entier à partir du nom de sa colonne
        /// </summary>
        /// <param name="reader">Le reader contenant la valeur recherchée</param>
        /// <param name="paramName">Le nom de la colonne</param>
        /// <returns></returns>
        public static int GetInt32(this DbDataReader reader, string paramName)
        {
            int i = 0;
            while(i < reader.VisibleFieldCount)
            {
                if (reader.GetName(i) == paramName)
                {
                    return reader.GetInt32(i);
                }
                i++;
            }
            return 0;
        }

        /// <summary>
        /// Récupère un long à partir du nom de sa colonne
        /// </summary>
        /// <param name="reader">Le reader contenant la valeur recherchée</param>
        /// <param name="paramName">Le nom de la colonne</param>
        /// <returns></returns>
        public static long GetInt64(this DbDataReader reader, string paramName)
        {
            int i = 0;
            while (i < reader.VisibleFieldCount)
            {
                if (reader.GetFieldValue<string>(i) == paramName)
                {
                    return reader.GetInt64(i);
                }
                i++;
            }
            return 0;
        }

        /// <summary>
        /// Récupère une chaîne à partir du nom de sa colonne
        /// </summary>
        /// <param name="reader">Le reader contenant la valeur recherchée</param>
        /// <param name="paramName">Le nom de la colonne</param>
        /// <returns></returns>
        public static string GetString(this DbDataReader reader, string paramName)
        {
            int i = 0;
            while (i < reader.VisibleFieldCount)
            {
                if (reader.GetFieldValue<string>(i) == paramName)
                {
                    return reader.GetString(i);
                }
                i++;
            }
            return string.Empty;
        }

        /// <summary>
        /// Récupère un double à partir du nom de sa colonne
        /// </summary>
        /// <param name="reader">Le reader contenant la valeur recherchée</param>
        /// <param name="paramName">Le nom de la colonne</param>
        /// <returns></returns>
        public static double GetDouble(this DbDataReader reader, string paramName)
        {
            int i = 0;
            while (i < reader.VisibleFieldCount)
            {
                if (reader.GetFieldValue<string>(i) == paramName)
                {
                    return reader.GetDouble(i);
                }
                i++;
            }
            return 0;
        }

        /// <summary>
        /// Récupère un booléen à partir du nom de sa colonne
        /// </summary>
        /// <param name="reader">Le reader contenant la valeur recherchée</param>
        /// <param name="paramName">Le nom de la colonne</param>
        /// <returns></returns>
        public static bool GetBoolean(this DbDataReader reader, string paramName)
        {
            int i = 0;
            while (i < reader.VisibleFieldCount)
            {
                if (reader.GetFieldValue<string>(i) == paramName)
                {
                    return reader.GetBoolean(i);
                }
                i++;
            }
            return false;
        }
    }
}
