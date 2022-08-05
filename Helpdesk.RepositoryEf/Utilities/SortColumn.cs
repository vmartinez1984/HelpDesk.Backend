namespace Helpdesk.RepositoryEf.Utilities
{
    public static class SortColumn
    {
        public static string GetSortColumn(this string sortColumn)
        {
            List<string> list;
            List<string> list2;

            list = sortColumn.Split(".").ToList();
            list2 = new List<string>();
            foreach (string item in list)
            {
                list2.Add(char.ToUpper(item[0]) + item.Substring(1));
            }

            return string.Join(".", list2);
        }
    }
}