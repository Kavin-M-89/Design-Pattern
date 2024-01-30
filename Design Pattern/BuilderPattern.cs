using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern
{
    //Build design pattern is building complex objects using many simple object and step by step approach (Client can keep any step as optional)
    public class BuilderPattern: IDesignPatten
    {
        public void Main()
        {
            ReportBuilder rb = new PDFReport();
            rb.CreateReport();
            rb.SetType();
            rb.SetHeader();
            rb.SetFooter();
            rb.SetMargin();
            var report = rb.GetReport();
            report.DisplayReport();

            //Here if we do not need margin, then we can skip setting the margin step
            ReportBuilder rb1 = new PDFReport();
            rb.CreateReport();
            rb.SetType();
            rb.SetHeader();
            rb.SetFooter();
            var report1 = rb.GetReport();
            report1.DisplayReport();
        }
    }

    public class Report
    {
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Margin { get; set; }
        public string Type { get; set; }

        public void DisplayReport()
        {
            Console.WriteLine("Type " + this.Type);
            Console.WriteLine("Header " + this.Header);
            Console.WriteLine("Footer " + this.Footer);
            Console.WriteLine("Margin " + this.Margin);
        }
    }

    public abstract class ReportBuilder
    {
        protected Report report;
        public abstract void SetHeader();
        public abstract void SetFooter();
        public abstract void SetMargin();
        public abstract void SetType();

        public void CreateReport()
        {
            report = new Report();
        }

        public Report GetReport()
        {
            return report;
        }
    }

    public class PDFReport: ReportBuilder
    {
        public override void SetHeader()
        {
            report.Header = "PDF Header";
        }
        public override void SetFooter()
        {
            report.Footer = "PDF Footer";
        }
        public override void SetMargin()
        {
            report.Margin = "PDF Margin";
        }
        public override void SetType()
        {
            report.Type = "PDF Type";
        }
    }
}
