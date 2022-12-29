//原型模式（克隆模式）
namespace PrototypePattern
{
    /// <summary>
    /// 抽象原型
    /// </summary>
    abstract class BaseShape
    {
        public int X;
        public int Y;
        public string Color;

        /// <summary>
        /// 常规构造函数
        /// </summary>
        public BaseShape()
        {

        }

        /// <summary>
        /// 原型构造函数
        /// </summary>
        /// <param name="source"></param>
        public BaseShape(BaseShape source) : this()
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Color = source.Color;
        }

        public abstract BaseShape Clone();
    }

    /// <summary>
    /// 具体原型
    /// </summary>
    class Circle : BaseShape
    {
        public int Radius;

        public Circle()
        {

        }

        public Circle(Circle source) : base(source)
        {
            this.Radius = source.Radius;
        }

        public override BaseShape Clone()
        {
            return new Circle(this);
        }
    }

    /// <summary>
    /// 具体原型
    /// </summary>
    class Rectangle : BaseShape
    {
        public int Width;
        public int Height;

        Rectangle(Rectangle source) : base(source)
        {
            this.Width = source.Width;
            this.Height = source.Height;
        }

        public override BaseShape Clone()
        {
            return new Rectangle(this);
        }
    }


    class Client
    {
        static void Main()
        {
            Circle circleA = new Circle();
            circleA.X = 10;
            circleA.Y = 10;
            circleA.Color = "Red";
            circleA.Radius = 5;

            Circle circleB = circleA.Clone() as Circle;
        }
    }
}