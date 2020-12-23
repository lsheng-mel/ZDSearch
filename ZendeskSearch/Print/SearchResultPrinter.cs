using System;
using System.Collections.Generic;
using System.Linq;
using Alba.CsConsoleFormat;

namespace ZendeskSearch.Print
{
    public static class SearchResultPrinter
    {
        public static void Print(IEnumerable<IPrintable> items)
        {
            var toPrint = items.ToList();
            if (!toPrint.Any())
            {
                var doc = new Document(
                    new Span("No result found. Please try again.") { Color = ConsoleColor.Green },
                    new Span("\n")
                    );
                
                ConsoleRenderer.RenderDocument(doc);
                return;
            }

            ConsoleRenderer.RenderDocument(new Document(
                new Span("\n"),
                new Span($"{toPrint.Count()} result(s) found:") { Color = ConsoleColor.Green},
                new Span("\n")
            ));

            foreach (var item in toPrint)
            {
                item.Print();
            }
        }
        
        public static void Print(IPrintable item)
        {
            var headerThickness = new LineThickness(LineWidth.Double, LineWidth.Single);
            
            var doc = new Document(
                new Grid
                {
                    Color = ConsoleColor.Gray,
                    Columns = { GridLength.Auto, GridLength.Auto},
                    Children =
                    {
                        new Cell("Property") { Stroke = headerThickness, Color = ConsoleColor.DarkGreen, Align = Align.Center},
                        new Cell("Value") { Stroke = headerThickness, Color = ConsoleColor.DarkGreen, Align = Align.Center},
                        item.GetType().GetProperties().Select(p => new[]
                        {
                            new Cell(p.Name),
                            new Cell(p.GetValue(item)?.ToPrintableString()) {Align = Align.Left}
                        })
                    }
                }
            );
            
            ConsoleRenderer.RenderDocument(doc);
        }

        private static string ToPrintableString(this object field)
        {
            return field is IEnumerable<string> ? string.Join(", ", (List<string>) field) : field.ToString();
        }
    }
}