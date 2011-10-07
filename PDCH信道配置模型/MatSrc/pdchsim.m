function [pdchnew]= pdchsim(traffic,pdchuse)
xx=traffic;
yy=pdchuse;
x=newton(xx,yy);%ลฃถู
pdchnew=traffic*x;
