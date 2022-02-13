using System;
using System.Collections.Generic;
using System.Windows;
using MediatR;
using Smokeball.Scraper.Application.Handlers.Query;
using Smokeball.Scraper.Presentation.Extensions;

namespace Smokeball.Scraper.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMediator _mediator;
        public MainWindow(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        public void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var positions = _mediator.Send(new GetLinkPositions
                {
                    SearchText = searchString.Text,
                    Url = urlText.Text,
                    Take = 100
                }).Result;
                DisplayOutput(positions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request failed - {ex.Message}. Please try again.", "Error");
            }            
        }

        private void DisplayOutput(List<int> positions)
        {
            if (positions?.Count > 0)
            {
                MessageBox.Show($"URL found at positions {positions.Format()}");
            }
            else
            {
                MessageBox.Show($"Could not find URL in top 100 search result.");
            }
        }
    }
}
