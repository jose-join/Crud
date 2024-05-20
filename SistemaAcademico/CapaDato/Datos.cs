using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public abstract class Datos
    {
        protected string aServidor = string.Empty;
        protected string aBase = string.Empty;
        protected string aCadenaConexion = string.Empty;
        protected IDbConnection aConexion;

        public string Servidor
        {
            get { return aServidor; }
            set { aServidor = value; }
        }

        public string Base
        {
            get { return aBase; }
            set { aBase = value; }
        }

        public abstract string CadenaConexion { get; set; }

        protected IDbConnection Conexion
        {
            get
            {
                if (null == aConexion)
                {
                    aConexion = CrearConexion(this.CadenaConexion);
                }
                if (aConexion.State != ConnectionState.Open)
                    aConexion.Open();
                return aConexion;
            }
        }

        public DataSet TraerDataSet_Consulta(string consulta)
        {
            DataSet dataSet = new DataSet();
            this.CrearDataAdapter_Consulta(consulta).Fill(dataSet);
            return dataSet;
        }

        public DataSet TraerDataSet(string procedimientoAlmacenado)
        {
            DataSet dataSet = new DataSet();
            this.CrearDataAdapter(procedimientoAlmacenado).Fill(dataSet);
            return dataSet;
        }

        public DataSet TraerDataSet(string procedimientoAlmacenado, params object[] parametros)
        {
            DataSet dataSet = new DataSet();
            this.CrearDataAdapter(procedimientoAlmacenado, parametros).Fill(dataSet);
            return dataSet;
        }

        public DataTable TraerDataTable_Consulta(string consulta)
        {
            return TraerDataSet_Consulta(consulta).Tables[0].Copy();
        }

        public DataTable TraerDataTable(string procedimientoAlmacenado)
        {
            return TraerDataSet(procedimientoAlmacenado).Tables[0].Copy();
        }

        public DataTable TraerDataTable(string procedimientoAlmacenado, params object[] parametros)
        {
            return TraerDataSet(procedimientoAlmacenado, parametros).Tables[0].Copy();
        }

        public DataRow TraerDataRow(string procedimientoAlmacenado)
        {
            return TraerDataSet(procedimientoAlmacenado).Tables[0].Rows[0];
        }

        public DataRow TraerDataRow(string procedimientoAlmacenado, params object[] parametros)
        {
            return TraerDataSet(procedimientoAlmacenado, parametros).Tables[0].Rows[0];
        }

        public string TraerValor(string procedimientoAlmacenado)
        {
            return TraerDataSet(procedimientoAlmacenado).Tables[0].Rows[0][0].ToString();
        }

        public string TraerValor(string procedimientoAlmacenado, params object[] parametros)
        {
            return TraerDataSet(procedimientoAlmacenado, parametros).Tables[0].Rows[0][0].ToString();
        }

        protected abstract IDbConnection CrearConexion(string cadena);
        protected abstract IDbCommand Comando(string procedimientoAlmacenado);
        protected abstract IDataAdapter CrearDataAdapter(string procedimientoAlmacenado, params object[] parametros);
        protected abstract void CargarParametros(IDbCommand comando, object[] parametros);
        protected abstract IDbCommand Comando_Consulta(string consulta);
        protected abstract IDataAdapter CrearDataAdapter_Consulta(string consulta, params object[] parametros);

        protected IDbTransaction mTransaccion;
        protected bool EnTransaccion = false;

        public void IniciarTransaccion()
        {
            mTransaccion = this.Conexion.BeginTransaction();
            EnTransaccion = true;
        }

        public void TerminarTransaccion()
        {
            try
            {
                mTransaccion.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mTransaccion = null;
                EnTransaccion = false;
            }
        }

        public void AbortarTransaccion()
        {
            try
            {
                mTransaccion.Rollback();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mTransaccion = null;
                EnTransaccion = false;
            }
        }
    }
}
