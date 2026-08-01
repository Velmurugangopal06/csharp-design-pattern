using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Solid
{
    public class Document
    {

    }

    public interface IPrinter
    {
        public void Print(Document document);
    }

    public interface IScanner
    {
        public void Scan(Document document);
    }

    public interface IFaxer
    {
        public void Fax(Document document);
    }

    public interface IMultiFunctionMachine: IPrinter, IScanner, IFaxer
    {

    }

    public class Printer: IPrinter
    {
        public void Print(Document d)
        {
            Console.WriteLine($"Print Function from Printer");
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(Document d)
        {
            Console.WriteLine($"Scan Function from Scanner");
        }
    }

    public class Faxer : IFaxer
    {
        public void Fax(Document d)
        {
            Console.WriteLine($"Fax Function from Faxer");
        }
    }

    public class PhotoCopier: IPrinter, IScanner
    {
        public void Print(Document d)
        {
            Console.WriteLine($"Print Function from PhotoCopier");
        }

        public void Scan(Document d)
        {
            Console.WriteLine($"Scan Function from PhotoCopier");
        }
    }

    public class MultiFunctionPrinter: IMultiFunctionMachine
    {
        private IPrinter _printer;
        private IScanner _scanner;
        private IFaxer _faxer;
        public MultiFunctionPrinter(IPrinter printer, IScanner scanner, IFaxer faxer)
        {
            _printer = printer;
            _scanner = scanner;
            _faxer = faxer;
        }

        public void Print(Document d)
        {
            _printer.Print(d);
            Console.WriteLine($"Print Function from MultiFunction Printer");
        }

        public void Scan(Document d)
        {
            _scanner.Scan(d);
            Console.WriteLine($"Scan Function from MultiFunction Printer");
        }

        public void Fax(Document d)
        {
            _faxer.Fax(d);
            Console.WriteLine($"Fax Function from MultiFunction Printer");
        }
    }


    public class InterfaceSeggregate
    {
        public static void Main()
        {
            var d = new Document();

            var pc = new PhotoCopier();
            pc.Print(d);
            pc.Scan(d);

            var p = new Printer();
            var s = new Scanner();
            var f = new Faxer();

            var mfp = new MultiFunctionPrinter(p, s, f);
            mfp.Print(d);
            mfp.Scan(d);
            mfp.Fax(d);
        }
    }
}
