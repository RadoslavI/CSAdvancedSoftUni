using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();

        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count { get => renovators.Count(); }

        public string AddRenovator(Renovator renovator)
        {
            if (String.IsNullOrEmpty(renovator.Name) || String.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (this.Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var toRemove = renovators.FirstOrDefault(x => x.Name == name);
            return renovators.Remove(toRemove);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = renovators.Where(x => x.Type == type).Count();

            if (count > 0)
            {
                renovators.RemoveAll(x => x.Type == type);
                return count;
            }
            else
                return 0;
        }
        public Renovator HireRenovator(string name)
        {
            var currRenovator = renovators.FirstOrDefault(x => x.Name == name);

            if (currRenovator != null)
                currRenovator.Hired = true;

            return currRenovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var returnRen = renovators.Where(x => x.Days >= days).ToList();
            return returnRen;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
