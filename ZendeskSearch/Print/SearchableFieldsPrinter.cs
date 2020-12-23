using System;
using System.Linq;
using Alba.CsConsoleFormat;
using ZendeskSearch.Model;

namespace ZendeskSearch.Print
{
    public interface ISearchableFieldsPrinter
    {
        void Print();
    }
    
    public class SearchableFieldsPrinter : ISearchableFieldsPrinter
    {
        public void Print()
        {
            // var headerThickness = new LineThickness(LineWidth.None, LineWidth.None);

            var doc = new Document(
                // new Grid
                // {
                //     Color = ConsoleColor.Gray,
                //     Columns = { GridLength.Auto },
                //     Children =
                //     {
                //         new Cell("Search Users with") { Stroke = headerThickness, Color = ConsoleColor.DarkBlue, Align = Align.Center},
                //         typeof(User).GetProperties().Select(p => new[]
                //         {
                //             new Cell(p.Name) {Align = Align.Left}
                //         })
                //     },
                //     Width = 80
                // },
                // new Grid
                // {
                //     Color = ConsoleColor.Gray,
                //     Columns = { GridLength.Auto },
                //     Children =
                //     {
                //         new Cell("Search Tickets with") { Stroke = headerThickness, Color = ConsoleColor.DarkBlue, Align = Align.Center},
                //         typeof(Ticket).GetProperties().Select(p => new[]
                //         {
                //             new Cell(p.Name) {Align = Align.Left}
                //         })
                //     },
                //     Width = 80
                // },
                // new Grid
                // {
                //     Color = ConsoleColor.Gray,
                //     Columns = { GridLength.Auto },
                //     Children =
                //     {
                //         new Cell("Search Organizations with") { Stroke = headerThickness, Color = ConsoleColor.DarkBlue, Align = Align.Center},
                //         typeof(Organization).GetProperties().Select(p => new[]
                //         {
                //             new Cell(p.Name) {Align = Align.Left, Stroke = new LineThickness(LineWidth.None, LineWidth.None)}
                //         })
                //     },
                //     Width = 80
                // }
                // CreateDiv<User>("Search Users with:"),
                // CreateDiv<Ticket>("Search Tickets with:"),
                // CreateDiv<Organization>("Search Organizations with:")
                
                CreateGrid<User>("Search Users with:"),
                CreateGrid<Ticket>("Search Tickets with:"),
                CreateGrid<Organization>("Search Organizations with:")
            );
            
            ConsoleRenderer.RenderDocument(doc);
        }

        private Div CreateDiv<T>(string title)
        {
            return new Div(
                new Div(title) {Color = ConsoleColor.DarkBlue},
                new Div()
                {
                    Children =
                    {
                        typeof(T).GetProperties().Select(p => new[]
                        {
                            new Cell(p.Name)
                                {Align = Align.Left, Stroke = new LineThickness(LineWidth.None, LineWidth.None)}
                        })
                    }
                }
            );
        }

        private Grid CreateGrid<T>(string title)
        {
            var headerThickness = new LineThickness(LineWidth.None, LineWidth.None);

            return new Grid
            {
                Color = ConsoleColor.Gray,
                Columns = {GridLength.Auto},
                Children =
                {
                    new Cell(title) {Stroke = headerThickness, Color = ConsoleColor.DarkBlue, Align = Align.Left},
                    typeof(Organization).GetProperties().Select(p => new[]
                    {
                        new Cell(p.Name)
                            {Align = Align.Left, Stroke = new LineThickness(LineWidth.None, LineWidth.None)}
                    })
                },
                Width = 80,
                Align = Align.Left,
                
            };
        }
    }
}