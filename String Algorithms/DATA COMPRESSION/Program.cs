using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_COMPRESSION
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("INput String for Encoding & Decoding: ");
            string input = Console.ReadLine();

            LZWEncoder lzwEncoder=new LZWEncoder();
            LZWDecoder lzwDecoder=new LZWDecoder();

            string code = lzwEncoder.Encode(input);
            
            string output = lzwDecoder.Decode(code);
            

            HuffmanTree huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(input);

            // Encode
            BitArray encoded = huffmanTree.Encode(input);

            Console.Write("Encoded by Huffman: ");
            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();
            Console.WriteLine("Encoded by LZW: {0}", code);

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Decoded by Huffman: {0}",decoded);
            Console.WriteLine("Decoded by LZW: {0}", output);

            Console.ReadKey();
        }
    }
}
