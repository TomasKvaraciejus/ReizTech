// 2-3 - Calculating maximum depth of Branch

namespace ReizTech
{
    class Task2_3
    {
        public static string input;

        class Branch
        {
            public List<Branch> branches = new List<Branch>(); // I assume that setting branches to public is allowed
        }

        public static void Main(string[] args)
        {
            Branch head = new Branch();

            /*head.branches.AddRange(new List<Branch>{ new Branch(), new Branch() }); // Discrete way to populate tree

            head.branches[0].branches.Add(new Branch());
            head.branches[1].branches.AddRange(new List<Branch> { new Branch(), new Branch(), new Branch() });

            head.branches[1].branches[0].branches.Add(new Branch());
            head.branches[1].branches[1].branches.AddRange(new List<Branch> { new Branch(), new Branch() });
            head.branches[1].branches[2].branches.Add(new Branch());

            head.branches[1].branches[1].branches[0].branches.Add(new Branch());*/

            input = "2 1 0 3 1 0 2 1 0 1 0 1 0"; // input string corresponds to tree presented in Task 2
            head = populateTree();

            Console.WriteLine($"Depth of Branch is {getDepth(head)}");
        }

        static Branch populateTree() // Populates tree according to string input - first character in input is branch count (limited to 9 per branch), tree is populated left to right
        {
            Branch head = new Branch();
            int newBranches = input[0] - 48;

            for (int i = 0; i < newBranches; ++i)
            {
                input = input.Substring(2);
                Branch nBranch = populateTree();
                head.branches.Add(nBranch);
            }

            return head;
        }

        static int getDepth(Branch head) // Recursively calculates maximum depth of Branch
        {
            int maxDepth = 0;

            foreach(Branch b in head.branches)
            {
                int curDepth = getDepth(b);
                if (curDepth > maxDepth)
                    maxDepth = curDepth;
            }

            return maxDepth + 1;
        }
    }
}