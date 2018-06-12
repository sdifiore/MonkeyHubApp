using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel
    {
        public string Descricao { get; set; }

        public MainViewModel()
        {
            Descricao = "Olá mundo! Eu estou aqui";
        }
    }
}
