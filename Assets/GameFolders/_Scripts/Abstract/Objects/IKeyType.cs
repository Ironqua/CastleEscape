public enum KeyType
{
    RedKey,BlueKey,None
}

public interface IKeyType 
{
  KeyType GetKey();
}
