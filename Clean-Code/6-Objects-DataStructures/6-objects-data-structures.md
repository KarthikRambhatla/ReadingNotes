Variables in objects are private, so that others do not depend on them and we will have freedom to change implementations. So you should not add getters and setters to expose them.

## Data Abstraction

Consider the implementations below for point

- Concrete Point

        public class Point {
            public double x;
            public double y;
        }

- Abstract Point

        public interface Point{
            double getX();
            double getY();
            void setCartesian(double x, double y);

            double getR();
            double getTheta();
            void setPolar(double r, double theta);
        }

The Abstract Point is more than a data structure, it enforces access policy. You can read individual coordinates independently. But when setting it, you must set them together. The implementation is abstracted away and you cannot tell whether it is rectangular or polar. 

The Concrete Point is implemented in rectangular. Even if we have them as private variables and use getters and setters, The implementation is exposed.

**Hiding implementation is not just putting another layer of functions between, it is about abstractions**

- Concrete Vehicle

        public interface Vehicle {
            double getFuelTankCapacityInGallons();
            double getGallonsOfGasoline();
        }
- Abstract Vehicle

        public interface Vehicle {
            double getPercentFuelRemaining();
        }
Second one is preferred, we do not want to expose details of data. Just express in abstract terms. Put serious thoughts, don't just blithely add getters/setters.

## Data/Object Anti-Symmetry


**Objects hide their data behind abstractions and expose functions that operate on that data.**

**Data Structures expose their data and have no meaningful functions**
