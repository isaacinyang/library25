using System;

namespace MemoryVerse;

public class Verse
{
    public string text;
    public string book;
    public int chapter;
    public int verse;

    public Verse(string text, string book, int chapter, int verse)
    {
        this.text = text;
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public List<string> WordList()
    {
        List<string> words = this.text.Split(' ').ToList();

        return words;
    }
}
