using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core
{
    internal interface IGames
    {
        public void StartGame(); // старт игры настройка и запуск внутри метод старта из сохранения
        public void StopGame(); // прерывание / окончание игры сохронение
        public void Settings(); // настройки
        public void StartWithSave(); // старт из сохранения
    }
}
