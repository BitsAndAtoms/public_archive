clc ;
clear all;
numberOfDataSets = 100;
dataPointsPerDataSet = 25;
counter = 1;
Lambda = 0.1:1.5:8;

gaussianBasisParamS = 0.1;


L = numberOfDataSets;
N = dataPointsPerDataSet;
gaussianBasisParamMu = 0:1/N:1;
gaussianBasisParamMu([1 end]) = []; 
xTraining   = sort(rand(1,N)');             % sampling from uniform distribution
hx = sin(2*pi*xTraining);
Mu = gaussianBasisParamMu;
%Mu = xTraining(1:end-1,1)';
S = gaussianBasisParamS;
gaussianBasisFunction = @(x,i) exp((-(x-Mu(i))^2)/2/S^2); 
%% generate basis function
% this is the gaussian basis function
%% Generate data set D 

newtraining = sort(rand(1,1000)'); 
newhx = sin(2*pi*newtraining);
newEpsilonTraining = normrnd(0,0.3,[1000 1]);         % sampling normal distribution
tNew1000       = newhx+newEpsilonTraining; 

for j = 1:1000
    for k = 1:length(Mu)
      newPhiMatrix(j,k) =  gaussianBasisFunction(newtraining(j),k);
    end
end
newphiMatrix = ([ones(1000,1),newPhiMatrix]);


for span = Lambda
    


for i = 1:L
epsilonTraining = normrnd(0,0.3,[N 1]);         % sampling normal distribution
tTraining       = hx+epsilonTraining;  % training set  
for j = 1:N
    for k = 1:length(Mu)
      PhiMatrix(j,k) =  gaussianBasisFunction(xTraining(j),k);
    end
end
phiMatrix = ([ones(N,1),PhiMatrix]);
X = phiMatrix;
parameterSet{i} = ((X'*X+span*eye(size(X))))\(X')*tTraining;
trainingX{i} = X;
targetOutput{i} = tTraining;
end

for i = 1:L
   predictedValueTraining(:,i) = trainingX{i}*parameterSet{i};
   
   % predictedValueTest = testInput(:,1:i)*parameterSet{i};
   %figure(i+2)  % use this to see the fit
   %plot(xTraining,tTraining,'rs',xTraining,predictedValueTraining,'k-');
   % errorRmsTraining(i) = sqrt(sum((tTraining-predictedValueTraining).^2)/nTraining);  
   % errorRmsTest(i)=sqrt(sum((tTest-predictedValueTest).^2)/nTest);
end
meanPredictedValueTraining = sum(predictedValueTraining,2)/L; %mean fx
variance(counter) = sum(sum((predictedValueTraining-meanPredictedValueTraining).^2)/L)/N;
biasSquare= sum((meanPredictedValueTraining-hx).^2)/N;
bias(counter) = biasSquare;



for i =1:L
   newpredictedValueTraining(:,i) = newphiMatrix *parameterSet{i};
end
newmeanPredictedValueTraining = sum(newpredictedValueTraining,2)/L; 

error(counter) = sqrt(sum((newmeanPredictedValueTraining-newhx).^2)/1000);

counter = counter+1;
end
 semilogy(log(Lambda),bias,log(Lambda),variance,log(Lambda),bias+variance,log(Lambda),error)

 
%mean fx

