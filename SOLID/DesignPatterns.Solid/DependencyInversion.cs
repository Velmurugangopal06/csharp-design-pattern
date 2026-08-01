using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid
{
    public enum Relationship
    {
        Parent,
        Child
    }

    public class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
    }

    public interface IRelationChildBrowser
    {
        public IEnumerable<Person> FindAllChildren(Person parent);
    }

    public interface IRelationGrandChildBrowser
    {
        public IEnumerable<Person> FindAllGrandChildren(Person grandParent);
    }

    public class RelationBrowser: IRelationChildBrowser, IRelationGrandChildBrowser
    {
        private List<(Person, Relationship, Person)> relations = new();

        public void AddChildren(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent)); 
        }

        public IEnumerable<Person> FindAllChildren(Person parent)
        {
            return relations.Where(w => 
                w.Item1.Name.Equals(parent.Name, StringComparison.OrdinalIgnoreCase)
                && w.Item2 == Relationship.Parent)
                .Select(s => s.Item3);
        }

        public IEnumerable<Person> FindAllGrandChildren(Person grandParent)
        {
            var grandChildrens = new List<Person>();

            var childrens = this.FindAllChildren(grandParent);
            foreach (var children in childrens)
            {
                grandChildrens.AddRange(this.FindAllChildren(children));
            }

            return grandChildrens;
        }
    }

    public class DependencyInversion
    {
        public static void Main()
        {
            var grandPa = new Person("Velayutham");
            var grandMa = new Person("Kantha");
            var child1 = new Person("Arumugam");
            var child2 = new Person("Gopalakrishnan");
            var child3 = new Person("Saravanan");
            var grandChild1 = new Person("Sathish");
            var grandChild2 = new Person("Velmurugan");
            var grandChild3 = new Person("Muthu");
            var grandChild4 = new Person("Selvam");
            var grandChild5 = new Person("Esakki");

            var rb = new RelationBrowser();
            rb.AddChildren(grandPa, child1);
            rb.AddChildren(grandPa, child2);
            rb.AddChildren(grandPa, child3);
            rb.AddChildren(child1, grandChild1);
            rb.AddChildren(child2, grandChild2);
            rb.AddChildren(child1, grandChild3);
            rb.AddChildren(child3, grandChild4);
            rb.AddChildren(child2, grandChild5);

            var childrenOfChild2 = rb.FindAllChildren(child2);
            Console.WriteLine($"Children of {child2.Name} - ");
            foreach(Person child in childrenOfChild2)
            {
                Console.WriteLine(child.Name);
            }

            var grandChildrenOfGrandPa = rb.FindAllGrandChildren(grandPa);
            Console.WriteLine($"Grand Children of {grandPa.Name} - ");
            foreach (Person grandChild in grandChildrenOfGrandPa)
            {
                Console.WriteLine(grandChild.Name);
            }
        }
    }
}
