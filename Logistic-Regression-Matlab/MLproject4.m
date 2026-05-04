%%              ECE 5332/4332
%% Binomial logistic regression
%% Real data set chosen from 
% https://archive.ics.uci.edu/ml/datasets/Blood+Transfusion+Service+Center


%% a) Synthetic data for binomial logistic regression
clc
clear all;
x1 = mvnrnd([0 0],[1 0.75; 0.75 1],5000);
x2 = mvnrnd([4 4],[1 0.75; 0.75 1],5000);
figure(1)
plot(x1(:,1),x1(:,2),'.',x2(:,1),x2(:,2),'.');
title('Synthetic dataset for logistic regression')
legend('class 1','class 2');
xlabel('feature vector - x')
ylabel('target - y')

%% initialization of the feature vectors, targets and weights matrix and preparing data
weightsInitial = zeros(1,2);  
features = [x1(:,1);x2(:,1)];
features = [ones(size(features,1),1) features]; % features with intercept
ydata = [x1(:,2);x2(:,2)];
target = [x1(:,2).*0;x2(:,2).*0+1];
scramble_data = [features target ydata];
scramble_data = scramble_data(randperm(size(scramble_data,1)),:); % for stochastic gradient descent
features = scramble_data(:,1:2); % reassign scrambled features
target = scramble_data(:,3);   % reassign scrambled data
numberOfFeatures = size(features,1);            % number of data points
weights = weightsInitial';
maxIter = 3000000;
tolerance = 10^-7;
stepSize = 3*(10^-5);
%% Gradient descent
tic;
i = 0;
while i < maxIter
 i = i+1;
values = weights'*features';          %transpose of weight vector times observed value xi
predictions = 1./(1+exp(-values));    %sigmoid used to arrive at predicted value
error = (target-predictions');        % error of prediction
gradient = (features')*(error);       % gradient
 value1 = weights;
weights = weights + stepSize/numberOfFeatures*gradient;
max(abs(weights-value1));
if max(abs(weights-value1))< tolerance %convergence criteria
    i = maxIter;
end
end
lossGD = abs(sum(target.*1./(1+exp(-values))'+(1-target).*log(1-1./(1+exp(-values))')));
weightsGD = weights;
scores = weights'*features';
test_y = round(1./(1+exp(-scores)));
accuracyGD = mean(double(target == test_y')*100);
tGD = toc;
figure(2)
plot(x1(:,1),x1(:,2),'r.',x2(:,1),x2(:,2),'r.');
hold on
count = 1;
for i = 1:numberOfFeatures
    if(target(i) ~= test_y(i))
        count = count+1;
        plot(features(i,2),scramble_data(i,4),'.k');
    end
end
hold off
title('Result using gradient descent')
legend('correct','','incorrect');
xlabel('feature vector - x')
xlabel('feature vector - x')
ylabel('target - y')
%%
clear weights
%% stochastic gradient descent
weights = weightsInitial';
 tic;
 i=0;
while i < maxIter
    i = i+1;
scores = weights'*features';
predictions = 1./(1+exp(-scores));
error = (target-predictions');
gradient = (features(50,:)')*(error(50));
value1 = weights;
weights = weights + (5*10^-5)*gradient;
if max(abs(weights-value1))< tolerance %convergence criteria
    i = maxIter;
end
end
lossSGD = abs(sum(target.*1./(1+exp(-scores))'+(1-target).*log(1-1./(1+exp(-scores))')));
weightsSGD = weights;
scores = weights'*features';
test_y = round(1./(1+exp(-scores)));
accuracySGD = mean(double(target == test_y')*100);
tSGD = toc;
figure(3)
plot(x1(:,1),x1(:,2),'r.',x2(:,1),x2(:,2),'r.');
hold on
count = 1;
for i = 1:numberOfFeatures
    if(target(i) ~= test_y(i))
        count = count+1;
        plot(features(i,2),scramble_data(i,4),'.k');
    end
end
hold off
title('Result using stochastic gradient descent')
legend('correct','','incorrect');
xlabel('feature vector - x')
ylabel('target - y')
clear weights

%~~~~~~~~~~~~~~~~Part B begins ~~~~~~~~~~%


%% matlab linear regression with logit function
 %% Real data
data = load("Data.txt");
x = data(:,1:end-1);
y = data(:,end);
train_per = 0.8;
test_per = 0.2;
train_set = round(size(x,1)*train_per); 
test_set = round(size(x,1)*(test_per+train_per));
x_train = x(1:train_set,:);
y_train = y(1:train_set,:);
x_test = x(train_set+1:test_set,:);
y_test = y(train_set+1:test_set,:);
% add bias
x_train = [ones(size(x_train,1), 1) x_train];
x_test = [ones(size(x_test,1), 1) x_test];
theta_zero = zeros(size(x_train,2), 1);
tic;
[J, grad] = compute_cost(theta_zero, x_train, y_train);
options = optimset('GradObj', 'on', 'MaxIter',maxIter);
theta = fminunc(@(t)compute_cost(t, x_train, y_train), theta_zero, options);
trainPredicted= testfun (theta, x_train);
accuracyTrain =  mean(double(trainPredicted == y_train)*100);
timeRealFunc1 = toc;
% figure(4)
% plot(x_train(:,4),y_train,'r.');
% hold on
% for i = 1: size(x_train,1)
% if(y_train(i) ~= trainPredicted(i))
% plot(x_train(i,4),y_train(i),'k.')
% end
% end
% hold off
tic;
test= testfun (theta, x_test);
accuracyTest =  mean(double(test == y_test)*100);
timeRealFunc2 = toc;
% % % figure(5)
% % % plot(x_test,y_test,'r.');
% % % hold on
% % % for i = 1: size(x_test,1)
% % % if(y_test(i,4) ~= test(i))
% % % plot(x_test(i),y_test(i),'k.')
% % % end
% % % end
hold off
clear weights;
%% using Gradient descent on real data
weights = zeros(1,5);
weights = weights';
features = x_train;
target = y_train;
 tic;
 i = 0;
while i < maxIter
    i = i+1;
values = weights'*features';          %transpose of weight vector times observed value xi
predictions = 1./(1+exp(-values));    %sigmoid used to arrive at predicted value
error = (target-predictions');        % error of prediction
gradient = (features')*(error);       % gradient
weights = weights + stepSize/numberOfFeatures*gradient;
value1 = weights;
if max(abs(weights-value1))< tolerance %convergence criteria
    i = maxIter;
end
end
lossGDRealData = abs(sum(target.*1./(1+exp(-values))'+(1-target).*log(1-1./(1+exp(-values))')));
weightsGD = weights;
scores = weights'*features';
train_y = round(1./(1+exp(-scores)));
accuracyGDtrain = mean(double(target == train_y')*100);
tGDtrain = toc;
tic;
clear features target
target = y_test;
features = x_test;
scores = weights'*features';
test_y = round(1./(1+exp(-scores)));
accuracyGDtest = mean(double(target == test_y')*100);
tGDtest=toc;

%% console output
clc;
fprintf("Number of iterations: " + maxIter + " for gradient methods");
fprintf('\n');
fprintf("The results of analysis of synthetic data of 10,000 points is as follows:" + '\n');
fprintf("The percentage accuracy of gradient descent is: " + accuracyGD + '\n');
fprintf("The time taken(in seconds) using gradient descent is: " + tGD + '\n');
fprintf("The percentage accuracy of stochastic gradient descent is: " + accuracySGD + '\n');
fprintf("The time (in seconds) taken using stochastic gradient descent is: " + tSGD + '\n');
fprintf("The loss with Gradient descent is: " + lossGD + " and with stochastic gradient descent is: " + lossSGD + '\n');
fprintf("Part A ends ");
fprintf('\n');
fprintf('\n');
fprintf("The results of analysis of real data is as follows:" + '\n');
fprintf("The percentage accuracy of gradient descent for training is: " + accuracyGDtrain + '\n');
fprintf("The time taken(in seconds) using gradient descent for training is: " + tGDtrain + '\n');
fprintf("The percentage accuracy of gradient descent for test is: " + accuracyGDtest + '\n');
fprintf("The time taken(in seconds) using gradient descent for test is: " + tGDtest + '\n');
fprintf("The percentage accuracy of fminunc for training is: " + accuracyTrain + '\n');
fprintf("The percentage accuracy of fminunc for test is: " + accuracyTest + '\n');
fprintf("The time (in seconds) taken using fminunc for training is: " + timeRealFunc1 + '\n');
fprintf("The time (in seconds) taken using fminunc for test is: " + timeRealFunc2 + '\n');
fprintf("The loss with Gradient descent is: " + lossGDRealData + '\n');
fprintf("%~~~~~~~~~~~~~~~~Part A ends ~~~~~~~~~~%");
fprintf("Part B and C end");
