using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOO.Util
{
    public static class ConverteValor
    {
        public static int ConverterValorInteiro(object valor)
        {
            int retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = int.Parse(valor.ToString());
            }

            return retorno;
        }

        public static int? ConverterValorInteiroNulo(object valor)
        {
            int? retorno = null;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = int.Parse(valor.ToString());
            }

            return retorno;
        }

        public static string ConverterValorString(object valor)
        {
            string retorno = String.Empty;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = valor.ToString();
            }

            return retorno;
        }

        public static DateTime ConverterValorData(object valor)
        {
            DateTime retorno = DateTime.Now;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToDateTime(valor);
            }

            return retorno;
        }

        public static DateTime? ConverterValorDataNull(object valor)
        {
            DateTime? retorno = null;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToDateTime(valor);
            }

            return retorno;
        }

        public static short ConverterValorShort(object valor)
        {
            short retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = short.Parse(valor.ToString());
            }

            return retorno;
        }

        public static decimal ConverterValorDecimal(object valor)
        {
            decimal retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = decimal.Parse(valor.ToString());
            }

            return retorno;
        }

        public static decimal? ConverterValorDecimalNulo(object valor)
        {
            decimal? retorno = null;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = decimal.Parse(valor.ToString());
            }

            return retorno;
        }

        public static bool ConverterValorBoolean(object valor)
        {
            bool retorno = false;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToBoolean(valor);
            }

            return retorno;
        }

        public static long ConverterValorLong(object valor)
        {
            long retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToInt64(valor);
            }

            return retorno;
        }

        public static long? ConverterValorLongNulo(object valor)
        {
            long? retorno = null;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToInt64(valor);
            }

            return retorno;
        }

        public static double ConverterValorDouble(object valor)
        {
            double retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToDouble(valor);
            }

            return retorno;
        }

        public static byte ConverterValorByte(object valor)
        {
            byte retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = Convert.ToByte(valor);
            }

            return retorno;
        }

        public static TimeSpan ConverterValorTimeSpan(object valor)
        {
            TimeSpan retorno = new TimeSpan(00, 00, 00);

            if (!DBNull.Value.Equals(valor))
            {
                retorno = TimeSpan.Parse(valor.ToString());
            }

            return retorno;
        }

        public static float ConverterValorFloat(object valor)
        {
            float retorno = 0;

            if (!DBNull.Value.Equals(valor))
            {
                retorno = float.Parse(valor.ToString());
            }

            return retorno;
        }
    }
}
