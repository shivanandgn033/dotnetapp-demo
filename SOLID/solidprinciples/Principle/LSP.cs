namespace solidprinciples.Principle;

//Liskov Substitution Principle (LSP)

// Objects of a derived class should be substitutable for objects of their base class without altering any of the desirable properties of that program.
// Essentially, if you have a base class, any derived class should be usable wherever the base class is used.

public interface IHasArea {
  int Area();
}

public class RectangleClass: IHasArea {
  public int Width {
    get;
    set;
  }
  public int Height {
    get;
    set;
  }

  public int Area() {
    return Width * Height;
  }
}

public class SquareClass: IHasArea {
  public int Side {
    get;
    set;
  }

  public int Area() {
    return Side * Side;
  }
}