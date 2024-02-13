
namespace HeapDataStructureAndProblems
{
    public class HeapDataStructureDriver{
        public static void Drive(){
            // 1
            // var pqPOC = new PriorityQueuePOC();
            // pqPOC.MinHeapPQ();
            // pqPOC.MaxHeapPQ();

            // 2
            var mergeKSortedArr = new MergeKSortedArrays();
            var lstOfLst = mergeKSortedArr.InitializeProblem();
            mergeKSortedArr.MergeKSortedArraysProb(lstOfLst);
            mergeKSortedArr.PrintInputOutput();

            
        }
    }
}