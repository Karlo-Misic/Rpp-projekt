using BusinessLogicLayer;
using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PresentationLayer1.UserControls
{
    public partial class UcLeaderboard : UserControl
    {
        private readonly UserService _userService;
        public ObservableCollection<USER> TopPlayers { get; set; } = new ObservableCollection<USER>();

        public UcLeaderboard()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            var players = _userService.GetTopPlayers(10);
            TopPlayers.Clear();
            foreach (var player in players)
            {
                TopPlayers.Add(player);
            }
            dgLeaderboard.ItemsSource = TopPlayers;

        }
    }
}
