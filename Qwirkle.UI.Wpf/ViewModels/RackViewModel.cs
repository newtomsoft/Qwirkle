﻿using Qwirkle.Core.PlayerContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Qwirkle.UI.Wpf.ViewModels
{
    public class RackViewModel : ViewModelBase, IPageViewModel
    {
        public List<TileViewModel> Tiles { get; set; }

        public TileViewModel SelectedTile { get; set; }



        public RackViewModel(Rack rack, Dispatcher uiDispatcher) : base(uiDispatcher)
        {


            string string0 = @"D:\Boulot\projets info\Qwirkle\Qwirkle.Infra.Persistence\Images\Tiles\Png\BlueCircle.png";
            string string1 = @"D:\Boulot\projets info\Qwirkle\Qwirkle.Infra.Persistence\Images\Tiles\Png\BlueClover.png";
            string string2 = @"D:\Boulot\projets info\Qwirkle\Qwirkle.Infra.Persistence\Images\Tiles\Png\GreenFourPointStar.png";
            string string3 = @"D:\Boulot\projets info\Qwirkle\Qwirkle.Infra.Persistence\Images\Tiles\Png\OrangeDiamond.png";
            string string4 = @"D:\Boulot\projets info\Qwirkle\Qwirkle.Infra.Persistence\Images\Tiles\Png\OrangeSquare.png";
            string string5 = @"D:\Boulot\projets info\Qwirkle\Qwirkle.Infra.Persistence\Images\Tiles\Png\RedEightPointStar.png";
            Tiles = new List<TileViewModel>
            {
                new TileViewModel { Name = "Name0", Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(string0)) },
                new TileViewModel { Name = "Name1", Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(string1)) },
                new TileViewModel { Name = "Name2", Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(string2)) },
                new TileViewModel { Name = "Name3", Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(string3)) },
                new TileViewModel { Name = "Name4", Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(string4)) },
                new TileViewModel { Name = "Name5", Image = new System.Windows.Media.Imaging.BitmapImage(new Uri(string5)) },
            };
        }
    }
}
