using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowType
    {
        African, European
    }

    public enum SwallowLoad
    {
        None, Coconut
    }

    /// <summary>
    /// Interface representing a swallow.
    /// It defines the properties and methods that any swallow type must implement.
    /// </summary>
    public interface ISwallow
    {
        SwallowType Type { get; }
        SwallowLoad Load { get; }
        void ApplyLoad(SwallowLoad load);
        double GetAirspeedVelocity();
    }

    /// <summary>
    /// Base class for swallows, implementing common properties and methods.
    /// This class cannot be instantiated directly and must be inherited by specific swallow types.
    /// </summary>    
    public abstract class SwallowBase : ISwallow
    {
        /// <summary>
        /// Gets the type of the swallow.
        /// This property indicates whether the swallow is African or European.
        /// </summary>
        public SwallowType Type { get; }

        /// <summary>
        /// Gets the load of the swallow.
        /// This property indicates whether the swallow is carrying a load, such as a coconut.
        /// </summary>
        public SwallowLoad Load { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SwallowBase class.
        /// This constructor is protected to prevent direct instantiation and requires a swallow type and load.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="load"></param>
        protected SwallowBase(SwallowType type)
        {
            Type = type;
            Load = SwallowLoad.None;
        }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        /// <summary>
        /// Applies a load to the swallow. 
        /// This method allows the swallow to carry a load, such as a coconut.
        /// </summary>
        public abstract double GetAirspeedVelocity();
    }

    /// <summary>
    /// Represents an African swallow.
    /// This class inherits from SwallowBase and implements the GetAirspeedVelocity method.
    /// </summary>
    public class AfricanSwallow : SwallowBase
    {
        /// <summary>
        /// Initializes a new instance of the AfricanSwallow class.
        /// This constructor requires a swallow load and sets the swallow type to African.  
        /// </summary>
        /// <param name="load"></param>
        public AfricanSwallow() : base(SwallowType.African) { }

        /// <summary>
        /// Gets the airspeed velocity of the African swallow.         
        /// This method returns the speed based on the load carried by the swallow.
        /// </summary>
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 22,
                SwallowLoad.Coconut => 18,
                _ => throw new InvalidOperationException("Unknown load")
            };
        }
    }

    /// <summary>
    /// Represents a European swallow.      
    /// This class inherits from SwallowBase and implements the GetAirspeedVelocity method.
    /// </summary>
    public class EuropeanSwallow : SwallowBase
    {
        /// <summary>
        /// Initializes a new instance of the EuropeanSwallow class.
        /// This constructor requires a swallow load and sets the swallow type to European.
        /// </summary>
        /// <param name="load"></param>
        public EuropeanSwallow() : base(SwallowType.European) { }

        /// <summary>
        /// Gets the airspeed velocity of the European swallow. 
        /// This method returns the speed based on the load carried by the swallow.
        /// </summary>
        public override double GetAirspeedVelocity()
        {
            return Load switch
            {
                SwallowLoad.None => 20,
                SwallowLoad.Coconut => 16,
                _ => throw new InvalidOperationException("Unknown load")
            };
        }
    }  

    /// <summary>
    /// Factory class for creating swallows.        
    /// This class provides a method to create swallows based on their type and load.
    /// </summary>
    public class SwallowFactory
    {
        /// <summary>
        /// Get Swallow based on the specified type and load.     
        /// This method returns an instance of ISwallow, which can be either an AfricanSwallow or a EuropeanSwallow.
        /// </summary>
        public ISwallow GetSwallow(SwallowType type) => type switch
        {
            SwallowType.African => new AfricanSwallow(),
            SwallowType.European => new EuropeanSwallow(),
            _ => throw new ArgumentException("Unknown swallow type")
        };

    }  
}