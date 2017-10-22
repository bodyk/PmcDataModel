# PmcDataModel
PmcDataModel - complex data structure, which holds only one number, and provide access to this number by index and via IEnumerable.

PmcDataModel is immutable. In task requirements there is no rule, which say, that number value may vary in different containers, matrix, positions or points. 

All configuration (like different count collections, special matrix rules etc.) must be pass through 'PmcConfiguration'.
