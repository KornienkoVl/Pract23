using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using static Pract23.Form1;
using System.Threading;

namespace Pract23
{
  
    public partial class Form1 : Form
    {
        private Graphics graphics;       
        private int resolution=1;         //Размер существа
        private int[,] field;            //Поле
        private int rows;               //Размер по у
        private int cols;                //Размер по Х
        World world;      
        private bool DayNight = true;   //True - день  false - ночь
        private int DayNightTime = 100; //длительность дня и ночи
        private int DayNightTimer = 0;  //Таймер дня и ночи 
        private bool SimStarted = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame() 
        {
            //Если игра уже идет, то новую начать можно только на паузе
            if (timer1.Enabled)
                return;
            SimStarted = true;
            buttonStop.Text = "Стоп";
            numericRes.Enabled = false;
            numericDensity.Enabled = false;
            numPlantSpeed.Enabled = false;
            numSheepSpeed.Enabled = false;
            numWolfSpeed.Enabled = false;
            //Подготовка игры
            DayNight = true;
            DayNightTimer = 0;
            resolution = (int)numericRes.Value;
            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            field = new int[cols, rows];

            world = new World(field,rows,cols, (int)numericDensity.Value);
            world.PlantRepSpeed = (int)numPlantSpeed.Value;
            world.SheepRepSpeed = (int)numSheepSpeed.Value;
            world.WolfRepSpeed = (int)numWolfSpeed.Value;
            world.CreateWorld();          
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);          
            timer1.Start();
        }

        private void NextGen()
        {            
            for (int x = Wolf.Hideout.X - 1; x <= Wolf.Hideout.X + 1; x++)
                for (int y = Wolf.Hideout.Y - 1; y <= Wolf.Hideout.Y + 1; y++)
                    World.field[Wolf.Hideout.X, Wolf.Hideout.Y] = 0;
            World.field[Wolf.Hideout.X, Wolf.Hideout.Y] = 4;

            kolPlant.Text = Convert.ToString(world.PlantNum);
            kolSheep.Text = Convert.ToString(world.SheepNum);
            kolWolf.Text = Convert.ToString(world.WolfNum);

            DayNightTimer++;
            if (DayNightTimer == DayNightTime) { DayNight = !DayNight; DayNightTimer = 0; World.WolfRepToday = false; }
            if (DayNight)
            {              
                //очистка поля
                graphics.Clear(Color.White);
                world.WolfLogicDay();
                World.field[Wolf.Hideout.X, Wolf.Hideout.Y] = 4;
                world.PlantLogic();
                world.SheepLogic();              
            }
            else
            {              
                graphics.Clear(Color.DarkSlateBlue);
                world.WolfLogicNight();
                World.field[Wolf.Hideout.X, Wolf.Hideout.Y] = 4;
            }
        //отрисовка       
            for (int x = 1;x < cols; x++)
            {
                for(int y = 1; y < rows;y++)
                {
                    if (World.field[x,y]==1)
                    {
                        if (DayNight)
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            graphics.FillRectangle(Brushes.MediumSpringGreen, rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            graphics.FillRectangle(Brushes.LightGreen, rect);
                        }
                       
                    }
                    if (World.field[x, y] == 2)
                    {
                        if (DayNight)
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            graphics.FillEllipse(Brushes.LightSkyBlue, rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            graphics.FillEllipse(Brushes.White, rect);
                        }

                    }                  
                    if (x == Wolf.Hideout.X && y == Wolf.Hideout.Y) //отрисовка убежища волков
                    {
                        if (DayNight)
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            for (int i = x - 1; i <= x + 1; i++)
                                for (int j = y - 1; j <= y + 1; j++)
                                    graphics.FillRectangle(Brushes.DimGray, i * resolution, j * resolution, resolution, resolution);

                            graphics.FillRectangle(Brushes.Black, rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            for (int i = x-1; i <= x+1; i++)
                                for (int j = y-1; j <= y+1; j++)
                                    graphics.FillRectangle(Brushes.DimGray, i * resolution, j * resolution, resolution, resolution);
                            graphics.FillRectangle(Brushes.OrangeRed, rect);
                        }

                    }
                    if (field[x, y] == 3)
                    {
                        if (DayNight)
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            graphics.FillEllipse(Brushes.Black, rect);
                        }
                        else
                        {
                            Rectangle rect = new Rectangle(x * resolution, y * resolution, resolution, resolution);
                            graphics.FillEllipse(Brushes.Crimson, rect);
                        }

                    }
                }
            }
                      pictureBox1.Refresh();
        }

        //ход и отрисовка
        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGen();           
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                buttonStop.Text = "Продолжить";
                timer1.Enabled = false;
                numericRes.Enabled = true;
                numericDensity.Enabled = true;
                numPlantSpeed.Enabled = true;
                numSheepSpeed.Enabled = true;
                numWolfSpeed.Enabled = true;
            }
            else
            {
                buttonStop.Text = "Стоп";
                timer1.Enabled = true;
                numericRes.Enabled = false;
                numericDensity.Enabled = false;
                numPlantSpeed.Enabled = false;
                numSheepSpeed.Enabled = false;
                numWolfSpeed.Enabled = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (SimStarted)
            {
                var Mx = e.Location.X / resolution;
                var My = e.Location.Y / resolution;

                if (Mx > 0 && Mx < cols && My > 0 && My < rows)
                {
                    if (World.field[Mx, My] == 0)
                    {
                        TypeName.Text = "";
                        MEnergy.Text = "Энергия:";
                        MLife.Text = "Время жизни:";
                        MEnergyNum.Text = "";
                        MLifeNum.Text = "";
                    }
                    if (World.field[Mx, My] == 1)//растения
                    {
                        foreach (Plant plant in world.Plants)
                        {
                            if (plant.CreatureCoords.X == Mx && plant.CreatureCoords.Y == My)
                            {
                                TypeName.Text = "Растение";
                                MEnergyNum.Text = Convert.ToString(plant.energy);
                                MLifeNum.Text = Convert.ToString(plant.lifetime);
                            }
                        }
                    }
                    if (World.field[Mx, My] == 2)//Овцы
                    {
                        foreach (Sheep sheep in world.Sheeps)
                        {
                            if (sheep.CreatureCoords.X == Mx && sheep.CreatureCoords.Y == My)
                            {
                                TypeName.Text = "Овца";
                                MEnergyNum.Text = Convert.ToString(sheep.energy);
                                MLifeNum.Text = Convert.ToString(sheep.lifetime);
                            }
                        }
                    }                   
                    if (World.field[Mx, My] == 4)//Логово волков
                    {                    
                                TypeName.Text = "Логово волков";
                                MEnergy.Text = "Запасы еды:";
                                MLife.Text = "";
                                MEnergyNum.Text = Convert.ToString(Wolf.StoredFood);                     
                    }
                    else
                    if (World.field[Mx, My] == 3)//Волки
                    {
                        foreach (Wolf wolf in world.Wolves)
                        {
                            if (wolf.CreatureCoords.X == Mx && wolf.CreatureCoords.Y == My)
                            {
                                TypeName.Text = "Волк";
                                MEnergyNum.Text = Convert.ToString(wolf.energy);
                                MLifeNum.Text = Convert.ToString(wolf.lifetime);
                            }
                        }
                    }
                }
            }
        }
    }
    public class World 
    {        
        public static int[,] field;      //Поле
        private int rows;               //Размер по у
        private int cols;                //Размер по Х
        private int density;            //Плотность создания существ
        //Скорости размножения существ
        public int SheepRepSpeed = 4;
        public int PlantRepSpeed = 4;
        public int WolfRepSpeed = 4;
        //Подсчет существ
        public int SheepNum = 0;
        public int PlantNum = 0;
        public int WolfNum = 2;
        //
        private int SheepCryCD = 10;    //Пауза между криками овец (значение)
        private int LocalSheepCryCD = 0;//Пауза между криками овец       
        private int StartWolf = 2;      //Начальное кол-во волков
        public static bool WolfRepToday = false;//флаг размножения волков
        public ArrayList Sheeps = new ArrayList(); //Список овец
        public ArrayList Plants = new ArrayList(); //Список растений
        public ArrayList Wolves = new ArrayList(); //Список волков
        public ArrayList NextGenCreatures = new ArrayList();   //Список для обновления кол-ва существ

        public World(int[,] fieldS, int rows, int cols, int density)
        {
            field = fieldS;
            this.rows = rows;
            this.cols = cols;
            this.density = density;
        }

        public void CreateWorld()
        {
            //Создание существ на карте
            Random rnd = new Random();
            //создание логова волков
            Wolf.Hideout.X = rnd.Next(3, cols - 3);
            Wolf.Hideout.Y = rnd.Next(3, rows - 3);
            field[Wolf.Hideout.X, Wolf.Hideout.Y] = 4;
            for (int i = 0; i < StartWolf; i++)
            {
                Wolf m1 = new Wolf(600);
                Wolves.Add(m1);
            }
            for (int x = 1; x < cols - 1; x++)
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    if (x != Wolf.Hideout.X && y != Wolf.Hideout.Y)
                    {
                        //шанс появления существа
                        int rndNum = rnd.Next(density);
                        if (rndNum == 0)
                        {
                            int rndType = rnd.Next(2);
                            if (rndType == 0) //растения
                            {
                                Plant m1 = new Plant(x, y, 1000);
                                Plants.Add(m1);
                                field[x, y] = 1;
                                PlantNum++;
                            }
                            if (rndType == 1)//овцы
                            {                                
                                Sheep m1 = new Sheep(x, y, 1000);
                                Sheeps.Add(m1);
                                field[x, y] = 2;
                                SheepNum++;
                            }
                        }
                        else field[x, y] = 0;
                    }
                }
            }
        }
        public void WolfLogicDay()
        {
            NextGenCreatures.Clear();
            //Волки днем              
            foreach (Wolf wolf in Wolves)
            {
                NextGenCreatures.Add(wolf);
                if (wolf.Inside == false)
                {
                    field[wolf.CreatureCoords.X, wolf.CreatureCoords.Y] = 0;
                    Coords target = wolf.LookAround(2, field, rows, cols);
                    if (target.X != -1)
                    {
                        wolf.GrabSheep();
                        foreach (Sheep sheep in Sheeps)
                        {
                            if (sheep.CreatureCoords.X == target.X && sheep.CreatureCoords.Y == target.Y)
                            {
                                SheepNum--;
                                Sheeps.Remove(sheep);
                                field[target.X, target.Y] = 0;
                                break;
                            }
                        }
                    }
                    target = wolf.CreatureCoords;
                    if (wolf.EnterHideout() == true) field[target.X, target.Y] = 0;
                    else
                        wolf.GoToTarget(Wolf.Hideout, field, rows, cols);

                    field[wolf.CreatureCoords.X, wolf.CreatureCoords.Y] = 3; //перемещение
                }
                else
                {
                    if (wolf.energy < 800) wolf.EatFood();
                    if (!WolfRepToday)
                    {
                        WolfRepToday = true;
                        Random rnd = new Random();
                        if (WolfRepSpeed > rnd.Next(4))
                        {
                            int baby = wolf.RepWolf(Wolves);
                            for (int i = 0; i < baby; i++)
                            {
                                Wolf m1 = new Wolf(500);
                                NextGenCreatures.Add(m1);
                                WolfNum++;
                            }
                        }
                    }
                }
                wolf.lifetime--;
            }
            AddWolves();
        }
        public void WolfLogicNight()
        {
            NextGenCreatures.Clear();
            foreach (Wolf wolf in Wolves)
            {
                if (wolf.energy < 1 || wolf.lifetime < 1)
                {
                    if (wolf.Inside == false)
                        field[wolf.CreatureCoords.X, wolf.CreatureCoords.Y] = 0;
                    WolfNum--;
                }
                else
                {
                    NextGenCreatures.Add(wolf);
                    if (wolf.Inside == true && wolf.energy < 600)
                    {
                        wolf.ExitHideout();
                    }
                    if (wolf.Inside == false) if (wolf.energy < 600)
                        {
                            field[wolf.CreatureCoords.X, wolf.CreatureCoords.Y] = 0;

                            Coords target = wolf.LookAround(2, field, rows, cols);
                            if (target.X != -1)
                            {
                                wolf.EatSheep();
                                foreach (Sheep sheep in Sheeps)
                                {
                                    if (sheep.CreatureCoords.X == target.X && sheep.CreatureCoords.Y == target.Y)
                                    {
                                        SheepNum--;
                                        Sheeps.Remove(sheep);
                                        field[target.X, target.Y] = 0;
                                        break;
                                    }
                                }
                            }
                            wolf.FindClosestSheep(Sheeps);
                            wolf.GoToTarget(Wolf.SheepCoords, field, rows, cols);
                        }
                        else
                        {
                            field[wolf.CreatureCoords.X, wolf.CreatureCoords.Y] = 0;
                            if (!wolf.CarrySheep)
                            {
                                //если на пути волка встречается овца, но волк направляется в убежище, то волк просто убивает овцу
                                Coords target = wolf.LookAround(2, field, rows, cols);
                                wolf.MakeMove(-1, field, rows, cols);
                                target = wolf.LookAround(2, field, rows, cols);
                                if (target.X != -1)
                                {
                                    wolf.GrabSheep();
                                    foreach (Sheep sheep in Sheeps)
                                    {
                                        if (sheep.CreatureCoords.X == target.X && sheep.CreatureCoords.Y == target.Y)
                                        {
                                            SheepNum--;
                                            Sheeps.Remove(sheep);
                                            field[target.X, target.Y] = 0;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Coords target = wolf.LookAround(2, field, rows, cols);
                                if (target.X != -1)
                                {
                                    foreach (Sheep sheep in Sheeps)
                                    {
                                        if (sheep.CreatureCoords.X == target.X && sheep.CreatureCoords.Y == target.Y)
                                        {
                                            SheepNum--;
                                            Sheeps.Remove(sheep);
                                            field[target.X, target.Y] = 0;
                                            break;
                                        }
                                    }
                                }
                                target = wolf.CreatureCoords;
                                if (wolf.EnterHideout()) { field[target.X, target.Y] = 0; }
                                else
                                    wolf.GoToTarget(Wolf.Hideout, field, rows, cols);
                            }
                        }
                    field[wolf.CreatureCoords.X, wolf.CreatureCoords.Y] = 3; //перемещение
                }
                wolf.energy--;
                wolf.lifetime--;
            }
            AddWolves();
        }
        public void PlantLogic()
        {
            NextGenCreatures.Clear();
            foreach (Plant plant in Plants)
            {
                if (plant.energy < 1 || plant.lifetime < 1)
                {
                    field[plant.CreatureCoords.X, plant.CreatureCoords.Y] = 0;
                    PlantNum--;
                }
                else
                {
                    NextGenCreatures.Add(plant);
                    Coords target = plant.LookAround(0, field, rows, cols);
                    if (target.X == -1) plant.NoSpaceAround = true;
                    else plant.NoSpaceAround = false;
                    if (!plant.NoSpaceAround)
                    {
                        plant.synthesis();
                        Random rnd = new Random();
                        if (PlantRepSpeed > rnd.Next(4))
                        if (plant.Reproduce(target, Plants))
                        {
                            Plant m1 = new Plant(target.X, target.Y, 500);
                            NextGenCreatures.Add(m1);
                            field[target.X, target.Y] = 1;
                            PlantNum++;
                        }
                    }
                    else plant.energy -= plant.GetDyingSpeed();
                }
                plant.lifetime -= 1;
            }
            AddPlants();
        }
        public void SheepLogic()
        {
            NextGenCreatures.Clear();
            foreach (Sheep sheep in Sheeps)
            {
                if (sheep.energy < 1 || sheep.lifetime < 1)
                {
                    field[sheep.CreatureCoords.X, sheep.CreatureCoords.Y] = 0;
                    SheepNum--;
                }
                else
                {
                    NextGenCreatures.Add(sheep);  //добавление существ в обновленную коллекцию 
                                                  //размножение                                              
                    Coords partnerCoords = sheep.LookAround(2, field, rows, cols);
                    if (partnerCoords.X != -1)                                        //если рядом есть партнер для размножения
                    {
                        Coords ChildCoords = sheep.LookAround(0, field, rows, cols);
                        if (ChildCoords.X != -1)
                        {
                            Random rnd = new Random();
                            if(SheepRepSpeed>rnd.Next(4))
                            if (sheep.Reproduce(partnerCoords, Sheeps))
                            {
                                Sheep m1 = new Sheep(ChildCoords.X, ChildCoords.Y, 500);
                                NextGenCreatures.Add(m1);
                                field[ChildCoords.X, ChildCoords.Y] = 2;
                                SheepNum++;
                            }
                        }
                    }
                    //поедание растений
                    bool FoundPlant = false;
                    //sheep.LookAround(1, field, rows, cols);
                    Coords target = sheep.LookAround(1, field, rows, cols);
                    if (target.X != -1)
                    {
                        FoundPlant = true;
                        sheep.EatPlant();
                        foreach (Plant plant in Plants)
                        {
                            if (plant.CreatureCoords.X == target.X && plant.CreatureCoords.Y == target.Y)
                            {
                                Plants.Remove(plant);
                                field[target.X, target.Y] = 0;
                                PlantNum--;
                                break;
                            }
                        }

                    }
                    field[sheep.CreatureCoords.X, sheep.CreatureCoords.Y] = 0;   //Очистка предыдущего местоположения
                                                                                 //Крик и следование за криком
                    if (FoundPlant) if (LocalSheepCryCD < 1) { Sheep.SheepCry = false; sheep.Cry(); LocalSheepCryCD = SheepCryCD; }
                    if (LocalSheepCryCD < 1) Sheep.SheepCry = false;
                    if (Sheep.SheepCry)
                    {
                        if (sheep.FollowCry(field, rows, cols))
                        {
                            //вытаптывание растений
                            foreach (Plant plant in Plants)
                            {
                                if (plant.CreatureCoords.X == sheep.CreatureCoords.X && plant.CreatureCoords.Y == sheep.CreatureCoords.Y)
                                {
                                    PlantNum--;
                                    Plants.Remove(plant);
                                    field[target.X, target.Y] = 0;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        //свободное движение                
                        if (sheep.MakeMove(-1, field, rows, cols))
                        {
                            //вытаптывание растений
                            foreach (Plant plant in Plants)
                            {
                                if (plant.CreatureCoords.X == sheep.CreatureCoords.X && plant.CreatureCoords.Y == sheep.CreatureCoords.Y)
                                {
                                    PlantNum--;
                                    Plants.Remove(plant);
                                    field[target.X, target.Y] = 0;
                                    break;
                                }
                            }
                        }
                    }
                    // передвижение существа на карте
                    field[sheep.CreatureCoords.X, sheep.CreatureCoords.Y] = 2; //перемещение
                    sheep.energy--;
                    sheep.lifetime--;
                }
            }
            LocalSheepCryCD--;
            AddSheeps();
        }

        private void AddPlants()
        {
            Plants.Clear();
            Plants = (ArrayList)NextGenCreatures.Clone();
        }
        private void AddSheeps()
        {
            Sheeps.Clear();
            Sheeps = (ArrayList)NextGenCreatures.Clone();
        }
        private void AddWolves()
        {
            Wolves.Clear();
            Wolves = (ArrayList)NextGenCreatures.Clone();
        }
    }

    public struct Coords
    {
        public int X;
        public int Y;
    }
    //Базовый класс существа. Может передвигаться, размножаться, осматриваться и умирать от недостатка энергии
    public class Creature
    {
        public int lifetime = 100;
        private static Random rnd = new Random();
        public int Type; //1-растение 2-овца 3-волк
        public int energy;
        public Coords CreatureCoords;
        public int savedDirection;
        public int moveDistance;

        //Создание существа
        public Creature(int type, int x, int y, int energy)
        {
            this.Type = type;
            this.energy = energy; //Смерть, если 0
            this.CreatureCoords.X = x;
            this.CreatureCoords.Y = y;
        }
        public bool MakeMove(int direction, int[,] field, int rows, int cols) //возвращает true, если ход на клетку с растением
        {
            //direction: 0-верх 1-вп 2-право 3-нп 4-низ 5-нл 6-лево 7-вл
            if (direction == -1) //если не передали направление
            {
                if (this.moveDistance != 0)
                {
                    //выбор направления
                    this.savedDirection = rnd.Next(8); //0-верх 1-вп 2-право 3-нп 4-низ 5-нл 6-лево 7-вл              
                                                       //добавить кол-во шагов в выбранном направлении
                    this.moveDistance = rnd.Next(20) + 1;
                }
            }
            else this.savedDirection = direction;

            Coords PlaceToMove = this.CreatureCoords; //Куда перемещаться. Стандартно - стоять на месте;           
                                                      //Вычисление координаты для перемещения
            if (this.savedDirection == 0) PlaceToMove.Y++;
            if (this.savedDirection == 1) { PlaceToMove.X++; PlaceToMove.Y++; }
            if (this.savedDirection == 2) PlaceToMove.X++;
            if (this.savedDirection == 3) { PlaceToMove.X++; PlaceToMove.Y--; }
            if (this.savedDirection == 4) PlaceToMove.Y--;
            if (this.savedDirection == 5) { PlaceToMove.X--; PlaceToMove.Y--; }
            if (this.savedDirection == 6) PlaceToMove.X--;
            if (this.savedDirection == 7) { PlaceToMove.X--; PlaceToMove.Y++; }


            //Проверка на возможность перемещения в указанную клетку(пусто ли в ней)
            bool plantstep = false;

            if (PlaceToMove.X > 0 && PlaceToMove.X < cols && PlaceToMove.Y > 0 && PlaceToMove.Y < rows)
            {
                if (field[PlaceToMove.X, PlaceToMove.Y] == 0) this.CreatureCoords = PlaceToMove;
                if(this.Type==3) if (field[PlaceToMove.X, PlaceToMove.Y] == 4) this.CreatureCoords = PlaceToMove;//Волки проходят сквозь убежище 
                if (field[PlaceToMove.X, PlaceToMove.Y] == 1) { this.CreatureCoords = PlaceToMove; plantstep = true; }
            }
            if (direction == -1) this.moveDistance--;
            return plantstep;
        }
        //Существо осматривает 8 клеток вокруг себя в поисках цели. Возвращает координаты цели.
        //Если найдено несколько целей, то выбирается случайная.
        public Coords LookAround(int target, int[,] field, int rows, int cols) 
        {
            int[] TargetsAround = new int[8];
            int masCounter = 0;

            //target = 0 - пустое место, 1 - растение, 2 - овца, 3-волк
            Coords TargetCoords;
            //верх 0
            if (CreatureCoords.Y + 1 < rows)
            if (field[CreatureCoords.X, CreatureCoords.Y+1]==target)
                {
                    TargetsAround[masCounter] = 0;
                    masCounter++;
                }
            //вп 1
            if (CreatureCoords.X + 1<cols && CreatureCoords.Y + 1 < rows)
                if (field[CreatureCoords.X+1, CreatureCoords.Y + 1] == target)
                {
                    TargetsAround[masCounter] = 1;
                    masCounter++;
                }
            //право 2
            if (CreatureCoords.X + 1 < cols)
            if (field[CreatureCoords.X + 1, CreatureCoords.Y] == target) 
                {
                    TargetsAround[masCounter] = 2;
                    masCounter++;
                }
            //нп 3
            if (CreatureCoords.X + 1 < cols && CreatureCoords.Y - 1 > 0 )
                if (field[CreatureCoords.X + 1, CreatureCoords.Y-1] == target)
                {
                    TargetsAround[masCounter] = 3;
                    masCounter++;
                }
            //низ 4
            if (CreatureCoords.Y - 1 > 0)
                if (field[CreatureCoords.X, CreatureCoords.Y - 1] == target) 
                {
                    TargetsAround[masCounter] = 4;
                    masCounter++;
                }
            //лн 5
            if (CreatureCoords.X - 1 > 0 && CreatureCoords.Y - 1 > 0)
                if (field[CreatureCoords.X-1, CreatureCoords.Y - 1] == target) 
                {
                    TargetsAround[masCounter] = 5;
                    masCounter++;                    
                }
            //лево 6
            if (CreatureCoords.X - 1 > 0)
            if (field[CreatureCoords.X - 1, CreatureCoords.Y] == target)
                {
                    TargetsAround[masCounter] = 6;
                    masCounter++;                   
                }
            //лв 7
            if (CreatureCoords.X - 1 > 0 && CreatureCoords.Y + 1 < rows)
                if (field[CreatureCoords.X - 1, CreatureCoords.Y+1] == target) 
                {
                    TargetsAround[masCounter] = 7;
                    masCounter++;                    
                }
            //Случайный выбор одного из доступных направлений
            if (masCounter > 0) //если хоть что-то найдено
            {
                int RandomTarget = rnd.Next(masCounter);

                if (TargetsAround[RandomTarget] == 0) { TargetCoords.X = CreatureCoords.X; TargetCoords.Y = CreatureCoords.Y + 1; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 1) { TargetCoords.X = CreatureCoords.X + 1; TargetCoords.Y = CreatureCoords.Y + 1; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 2) { TargetCoords.X = CreatureCoords.X + 1; TargetCoords.Y = CreatureCoords.Y; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 3) { TargetCoords.X = CreatureCoords.X + 1; TargetCoords.Y = CreatureCoords.Y - 1; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 4) { TargetCoords.X = CreatureCoords.X; TargetCoords.Y = CreatureCoords.Y - 1; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 5) { TargetCoords.X = CreatureCoords.X - 1; TargetCoords.Y = CreatureCoords.Y - 1; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 6) { TargetCoords.X = CreatureCoords.X - 1; TargetCoords.Y = CreatureCoords.Y; return TargetCoords; }
                if (TargetsAround[RandomTarget] == 7) { TargetCoords.X = CreatureCoords.X - 1; TargetCoords.Y = CreatureCoords.Y + 1; return TargetCoords; }
            }
            //координаты -1 -1, если цель не найдена
            TargetCoords.X = -1;
            TargetCoords.Y = -1;

            return TargetCoords;
        }
        //Трата энергии родителей на рождение нового существа
        public bool Reproduce(Coords coords, ArrayList Creatures) //Передаются координаты второго родителя
        {
            if (this.energy > 750)
            {
                this.energy = this.energy - 500;
                if (this.Type > 1) //Растения не нуждаются в партнере
                {
                    if(this.Type == 2)//овцы
                    foreach (Sheep creature in Creatures)
                    {
                        if (creature.CreatureCoords.X == coords.X && creature.CreatureCoords.Y == coords.Y)
                            if (creature.energy > 750) { creature.energy = creature.energy - 500; return true; }
                    }                  
                }
                else return true;
            }
            return false;
        }
    }
    //Растение. Может фотосинтезировать, если вокруг есть свободные клетки
    public class Plant : Creature
    {
        static int synVol = 15;            //Кол-во энергии за тик фотосинтеза
        static int dyingSpeed = 1000;        //Если нет возможности фотосинтезировать, то растение теряет данное кол-во энергии каждый тик таймера.      
        public bool NoSpaceAround = false;        //Если нет свободного места вокруг растения - true
        public Plant(int x, int y, int energy) : base (1, x, y, energy) 
        { 

        }

        public void synthesis()
        {
            this.energy += synVol;
        }

        public void ChangeSynVol(int NewVol)
        { 
            synVol= NewVol;
        }

        public void ChangeDyingSpd(int NewDyingSpd)
        {
            dyingSpeed = NewDyingSpd;
        }

        public int GetDyingSpeed()
        {
            return dyingSpeed;
        }


    }
    //Овца. Может издавать крик, на который будут идти сородичи. Поедает растения.
    public class Sheep : Creature
    {
        public static bool SheepCry = false;
        public static Coords CryCoords;       
        public Sheep(int x, int y, int energy) : base(2, x, y, energy)
        {
            lifetime = 500;
        }

        public void EatPlant()
        {
            energy += 200;
        }

        public void Cry()
        { 
            if (SheepCry == false)
            {
                Random rnd = new Random();
                if (rnd.Next(3) == 0)              
               {
                    SheepCry = true;
                    CryCoords = this.CreatureCoords;
               }
                    return;

            }
        }
        public bool FollowCry(int[,] field, int rows, int cols)
        {           
            int direction = -1;
            int Xdiff;
            int Ydiff;
            //вычислить направление, в котором находится крик
            //Приоритентно выполняется движение по диагонали
            Xdiff = CreatureCoords.X - CryCoords.X;
            Ydiff = CreatureCoords.Y - CryCoords.Y;
            //direction: 0-верх 1-вп 2-право 3-нп 4-низ 5-нл 6-лево 7-лв
            if (Xdiff < 0 && Ydiff < 0) direction = 1;
            if (Xdiff < 0 && Ydiff > 0) direction = 3;
            if (Xdiff > 0 && Ydiff < 0) direction = 7;
            if (Xdiff > 0 && Ydiff > 0) direction = 5;
            //направление по координатным осям
            if (Xdiff == 0 && Ydiff < 0) direction = 0;
            if (Xdiff == 0 && Ydiff > 0) direction = 4;
            if (Xdiff < 0 && Ydiff == 0) direction = 2;
            if (Xdiff > 0 && Ydiff == 0) direction = 6;
            //передать направление функции MakeMove
            bool plantStep = MakeMove(direction, field, rows, cols);
            return plantStep;
        }        

    }
    //Волк. Ночью выходит на охоту за овцами, если голоден. Идет к ближайшей овце. После еды передвигается свободно.
    //Если во время свободного перемещения сталкивается с овцой, то уносит её в логово и остается в нём.
    //Днём уходит в логово.
    public class Wolf : Creature
    {
        public static Coords Hideout;
        public static int StoredFood;
        public bool CarrySheep = false;
        public static Coords SheepCoords;
        public bool Inside = true;
        public Wolf(int energy) : base(3, Hideout.X, Hideout.Y, energy)
        {
            lifetime = 1000;
        }
        //Выход из убежища
        public bool ExitHideout()
        {
            if (Inside)
                if (this.energy < 600)
                {
                    this.CreatureCoords.X = Hideout.X;
                    this.CreatureCoords.Y = Hideout.Y-1;
                    this.Inside = false;
                    return true;
                }
            return false;
        }
        //Вход в убежище
        public bool EnterHideout()
        {
            for(int x=Hideout.X-1;x<=Hideout.X+1;x++)
                for(int y = Hideout.Y-1; y<=Hideout.Y+1;y++)
                {
                    if (this.CreatureCoords.X == x && this.CreatureCoords.Y == y)
                    {
                        this.Inside = true;
                        this.CreatureCoords.X = Hideout.X;
                        this.CreatureCoords.Y = Hideout.Y;
                        if (this.CarrySheep)
                        {
                            StoredFood++;
                            this.CarrySheep = false;
                        }
                        return true;
                    }
                }
            return false;
        }
        //Возвращает количество рожденных 
        public int RepWolf(ArrayList Creatures) 
        {
            int Children = 0;
            int Count = 0;
            foreach (Wolf creature in Creatures)
            {
                if (creature.energy > 900) Count++;

            }
            Count = Count / 2;
            Count = Count * 2;
            Children = Count;
            foreach (Wolf creature in Creatures)
            {
                if (Count > 0)
                {
                    if (creature.energy > 900) { creature.energy = creature.energy - 750; Count--; }
                }
            }
            return Children;
        }

        public void EatSheep()
        {
            this.energy += 500;

        }
        public void EatFood()
        {
            if (StoredFood > 0)
            {
                StoredFood--;
                this.energy += 500;
            }
        }
        public void GrabSheep()
        {
            this.CarrySheep = true;
        }

        //нахождение ближайшей овцы
        public void FindClosestSheep(ArrayList Sheeps)
        {
            if(this.energy < 600) 
            {
                int MinDist = -1;
                foreach (Sheep sheep in Sheeps)
                {
                    if (MinDist == -1) {
                        MinDist = Math.Abs(this.CreatureCoords.X - sheep.CreatureCoords.X) + Math.Abs(this.CreatureCoords.Y - sheep.CreatureCoords.Y);
                        Wolf.SheepCoords = sheep.CreatureCoords;
                    }
                    else if (MinDist > Math.Abs(this.CreatureCoords.X - sheep.CreatureCoords.X) + Math.Abs(this.CreatureCoords.Y - sheep.CreatureCoords.Y))
                    {
                        MinDist = Math.Abs(this.CreatureCoords.X - sheep.CreatureCoords.X) + Math.Abs(this.CreatureCoords.Y - sheep.CreatureCoords.Y);
                        Wolf.SheepCoords = sheep.CreatureCoords;
                    }
                }
            }
        }

        public bool GoToTarget(Coords Target, int[,] field, int rows, int cols)
        {
            int direction = -1;
            int Xdiff;
            int Ydiff;
            //вычислить направление, в котором находится крик
            //Приоритентно выполняется движение по диагонали
            Xdiff = CreatureCoords.X - Target.X;
            Ydiff = CreatureCoords.Y - Target.Y;
            //direction: 0-верх 1-вп 2-право 3-нп 4-низ 5-нл 6-лево 7-лв
            if (Xdiff < 0 && Ydiff < 0) direction = 1;
            if (Xdiff < 0 && Ydiff > 0) direction = 3;
            if (Xdiff > 0 && Ydiff < 0) direction = 7;
            if (Xdiff > 0 && Ydiff > 0) direction = 5;
            //направление по координатным осям
            if (Xdiff == 0 && Ydiff < 0) direction = 0;
            if (Xdiff == 0 && Ydiff > 0) direction = 4;
            if (Xdiff < 0 && Ydiff == 0) direction = 2;
            if (Xdiff > 0 && Ydiff == 0) direction = 6;
            //передать направление функции MakeMove
            bool plantStep = MakeMove(direction, field, rows, cols);
            return plantStep;
        }
    }
}
