using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake<T>:IEnumerable<T>
{
    private IList<T> stones;

    public Lake(List<T> stones)
    {
        this.stones = new List<T>(stones);
    }

    public IEnumerator<T> GetEnumerator()
    {
        
        for (int i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }
        var lastOddIndex = this.stones.Count % 2 == 0 ? this.stones.Count - 1 : this.stones.Count - 2;
        for (int i = lastOddIndex; i >= 0; i -= 2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}