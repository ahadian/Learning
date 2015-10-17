function [pos] = binarySearch(Items,item)
low=1;
high=length(Items);
mid=0;
while(low<high)
mid=floor((low+high)/2);
if(item<=Items(mid))
high=mid;
else 
low=mid+1;
end
end
pos = low;
end
