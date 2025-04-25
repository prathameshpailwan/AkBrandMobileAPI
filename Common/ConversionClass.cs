using System.Data;

namespace AkBrandMobile.Common
{
    public class ConversionsClass
    {

        public Dictionary<string, object> CreateParametersFromModel<T>(T model)
        {
            var parameters = new Dictionary<string, object>();

            if (model != null)
            {
                var properties = typeof(T).GetProperties();
                foreach (var prop in properties)
                {
                    string name = prop.Name;
                    object value = prop.GetValue(model) ?? DBNull.Value; // Handle null values
                    parameters.Add(name, value);
                }
            }

            return parameters;
        }


        //Convert To Datatable
        public DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Add columns based on the properties of the object
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add rows for each item in the list
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }
}
