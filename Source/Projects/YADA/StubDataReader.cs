using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YADA
{
    public class StubDataReader : IDataReader
    {
        private int CurrentIteration { get; set; }
        private int TotalIterations { get; set; }
        private Tuple<string, string> CurrentRow { get; set; }

        public StubDataReader(int iterations)
        {
            CurrentIteration = 0;
            TotalIterations = iterations;
            CurrentRow = new Tuple<string, string>("id value", "description value");
        }

        public void Close()
        {
            
        }

        public int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public DataTable GetSchemaTable()
        {
            var schema = new DataTable();
            schema.Columns.Add("ColumnName");
            schema.Rows.Add("ID");
            schema.Rows.Add("Description");

            return schema;
        }

        public bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            ++CurrentIteration;

            return CurrentIteration <= TotalIterations;
        }

        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int FieldCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            values[0] = CurrentRow.Item1;
            values[1] = CurrentRow.Item2;

            return 2;
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public object this[int i]
        {
            get { if (i == 0) return CurrentRow.Item1; else if (i == 1) return CurrentRow.Item2; else throw new ArgumentException(); }
        }
    }
}
