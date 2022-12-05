using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Days;

internal class Day5
{
    record Instruction(int Quantity, int From, int To);

    internal static string GetResultPartOne()
    {
        List<string> input = RequestInput.GetFormatedCollection(5);

        Dictionary<int, Stack<char>> cajasApiladas = GetPilasDeCajas();
        List<Instruction> instructions = GetInstructions(input);

        MoveBoxes(ref cajasApiladas, instructions);

        StringBuilder builder = new();
        foreach (var listStacks in cajasApiladas)
        {
            builder.AppendLine($"{listStacks.Key} - {listStacks.Value.Pop()}");
        }
        return builder.ToString();
    }


    internal static object GetResultPartTwo()
    {
        List<string> input = RequestInput.GetFormatedCollection(5);

        Dictionary<int, Stack<char>> boxes = GetPilasDeCajas();
        List<Instruction> instructions = GetInstructions(input);

        MoveBoxesWithTheFuckingCrateMover9001(ref boxes, instructions);

        StringBuilder builder = new();
        foreach (var listStacks in boxes)
        {
            builder.AppendLine($"{listStacks.Key} - {listStacks.Value.Pop()}");
        }
        return builder.ToString();
    }

    private static void MoveBoxesWithTheFuckingCrateMover9001(ref Dictionary<int, Stack<char>> cajasApiladas, List<Instruction> instructions)
    {
        int counter = 0;
        foreach (Instruction _instruction in instructions)
        {
            counter++;
            List<char> myFuckingBoxes = new();
            for (int i = 0; i < _instruction.Quantity; i++)
            {
                var box = cajasApiladas[_instruction.From].Pop();
                myFuckingBoxes.Add(box);
            }
            myFuckingBoxes.Reverse();
            foreach (var box in myFuckingBoxes) { 
                cajasApiladas[_instruction.To].Push(box);
            }
        }
    }

    private static void MoveBoxes(
            ref Dictionary<int, Stack<char>> cajasApiladas,
            List<Instruction> instructions)
    {
        int counter = 0;
        foreach (Instruction _instruction in instructions)
        {
            counter++;
            for (int i = 0; i < _instruction.Quantity; i++)
            {
                var box = cajasApiladas[_instruction.From].Pop();
                cajasApiladas[_instruction.To].Push(box);
            }
        }
    }

    private static Dictionary<int, Stack<char>> GetPilasDeCajas()
    {
        Dictionary<int, Stack<char>> pilaDeCajas = new()
        {
            {  1, new Stack<char>(new char[]{ 'P', 'D', 'Q', 'R', 'V', 'B', 'H', 'F' }) },
            {  2, new Stack<char>(new char[]{ 'V', 'W', 'Q', 'Z', 'D', 'L' }) },
            {  3, new Stack<char>(new char[]{ 'C', 'P', 'R', 'G', 'Q', 'Z', 'L', 'H' }) },
            {  4, new Stack<char>(new char[]{ 'B', 'V', 'J', 'G', 'H', 'D', 'R' }) },
            {  5, new Stack<char>(new char[]{ 'C', 'L', 'W', 'Z' }) },
            {  6, new Stack<char>(new char[]{ 'M', 'V', 'G', 'T', 'N', 'P', 'R', 'J' }) },
            {  7, new Stack<char>(new char[]{ 'S', 'B', 'M', 'V', 'L', 'R', 'J' }) },
            {  8, new Stack<char>(new char[]{ 'J', 'P', 'D' }) },
            {  9, new Stack<char>(new char[]{ 'V', 'W', 'N', 'C', 'D' }) },
        };

        Dictionary<int, Stack<char>> pilaDeCajasOrdenadas = new();

        //reverse
        foreach (var column in pilaDeCajas)
        {
            Stack<char> reverse = new();

            while (column.Value.Count != 0)
            {
                reverse.Push(column.Value.Pop());
            }

            pilaDeCajasOrdenadas.Add(column.Key, reverse);
        }

        return pilaDeCajasOrdenadas;
    }

    private static List<Instruction> GetInstructions(List<string> input)
    {
        List<Instruction> instructions = new();
        foreach (string instruction in input)
        {
            if (instruction.StartsWith('m'))
            {
                var matches = Regex.Matches(instruction, "([\\d]{1,})").ToArray();

                instructions.Add(new Instruction(
                    int.Parse(matches[0].Value),
                    int.Parse(matches[1].Value),
                    int.Parse(matches[2].Value)));
            }
        }
        return instructions;
    }
}
