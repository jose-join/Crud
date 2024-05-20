using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class DatosSQL : Datos
    {
        static Hashtable ColComandos = new Hashtable();
        private static string Cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;

        public DatosSQL() { }

        public DatosSQL(string cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion;
        }

        public DatosSQL(string servidor, string @base)
        {
            this.Base = @base;
            this.Servidor = servidor;
        }

        public override string CadenaConexion
        {
            get { return Cadena; }
            set { this.aCadenaConexion = value; }
        }

        protected override void CargarParametros(IDbCommand oComando, object[] args)
        {
            for (int i = 0; i < oComando.Parameters.Count - 1; i++)
            {
                SqlParameter P = (SqlParameter)oComando.Parameters[i + 1];
                if (i < args.Length)
                    P.Value = args[i];
                else
                    P.Value = null;
            }
        }

        protected override IDbCommand Comando(string procedimientoAlmacenado)
        {
            SqlCommand oComando;
            if (ColComandos.Contains(procedimientoAlmacenado))
                oComando = (SqlCommand)ColComandos[procedimientoAlmacenado];
            else
            {
                SqlConnection oConexion = new SqlConnection(this.CadenaConexion);
                oConexion.Open();
                oComando = new SqlCommand(procedimientoAlmacenado, oConexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlCommandBuilder.DeriveParameters(oComando);
                oConexion.Close();
                oConexion.Dispose();
                ColComandos.Add(procedimientoAlmacenado, oComando);
            }
            oComando.Connection = (SqlConnection)this.Conexion;
            return oComando;
        }

        protected override IDbCommand Comando_Consulta(string consulta)
        {
            SqlCommand oComando;
            if (ColComandos.Contains(consulta))
                oComando = (SqlCommand)ColComandos[consulta];
            else
            {
                SqlConnection oConexion = new SqlConnection(this.CadenaConexion);
                oConexion.Open();
                oComando = new SqlCommand(consulta, oConexion)
                {
                    CommandType = CommandType.Text
                };
                oConexion.Close();
                oConexion.Dispose();
                ColComandos.Add(consulta, oComando);
            }
            oComando.Connection = (SqlConnection)this.Conexion;
            return oComando;
        }

        protected override IDbConnection CrearConexion(string cadenaConexion)
        {
            return new SqlConnection(cadenaConexion);
        }

        protected override IDataAdapter CrearDataAdapter(string procedimientoAlmacenado, params object[] args)
        {
            SqlDataAdapter oAdapter = new SqlDataAdapter((SqlCommand)Comando(procedimientoAlmacenado));
            if (args.Length != 0)
                CargarParametros(oAdapter.SelectCommand, args);
            return oAdapter;
        }

        protected override IDataAdapter CrearDataAdapter_Consulta(string consulta, params object[] args)
        {
            SqlDataAdapter oAdapter = new SqlDataAdapter((SqlCommand)Comando_Consulta(consulta));
            if (args.Length != 0)
                CargarParametros(oAdapter.SelectCommand, args);
            return oAdapter;
        }

        public int Ejecutar(string procedimientoAlmacenado, params object[] parametros)
        {
            using (IDbCommand comando = Comando(procedimientoAlmacenado))
            {
                CargarParametros(comando, parametros);
                return comando.ExecuteNonQuery();
            }
        }
    }
}
