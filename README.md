# BIGDATA-ANALYSIS

## 1st project
### Preprocessing program
Program reads points (x,y,z,i) from the .txt file and put them into sorted list (sorted by X,Y).<br> Then program saves points structure as binary file.

<b>Run the program with parameters:</b><br>
*input_file*   - input file with raw ASCII points data <br>
*preprocessed_file*  - output file where points are preprocessed

### Histogram program
Program read file chunk by chunk. Chunk size is definied by user as <b>M</b> parameter.<br> Then program adds points that exsists in bounding box definied in parameters by user.<br> Program uses binary search to find first point from bounding box inside chunk.<br> By <b>Histogram</b> class program calculates every needed parameter to display statistics.

<b>Run the program with parameters:</b><br>
 *M*                - maximum size of memory usage <br>
 *minX*              - minimum X value of points of interest<br>
 *maxX*              - maximum X value of points of interest<br>
 *minY*              - minimum Y value of points of interest<br>
 *maxY*              - maximum Y value of points of interest<br>
 *bin_size*          - size of histogram bin used in statistics calculation<br>
 *selection*         - enable switching of which point parameter should be used for statistics summary, either intensity (i) or point height (z).
 
 #### Input file format
 *394372.82 39157.52 217.57 61 <br>
394372.82 39165.22 218.13 39<br>
394372.82 39186.13 221.59 46*
### Example
 #### Run with parameters: 
 *output 1 394364 394374 39150 39160 5 i*
 #### Output
 *Number of points inside given bounding box: 1031<br>
Calculated average: 37,3346<br>
Calculated deviation: 19,7108<br>
Calculated skewness: 1,22782<br>
Calculated kurtosis: 4,83795<br>
Number of bins: 26<br>
Number of data reads from the input file: 37*
