%% Convolution Neural Network for image recognition
clc 
clear all
close all
% check if Neural net cnnNET is already present in current folder
currentFolder = cd;
fileExisting  = (exist(fullfile(currentFolder, 'cnnNet.mat'), 'file') == 2);
% run CNN construction only if net is not already saved and trained

if ~fileExisting 
%% load MNIST training and test data
imagesTrain =  loadMNISTImages('Select training image set','train-images.idx3-ubyte'); % load MNIST images
labelsTrain =  loadMNISTLabels('Select training label set','train-labels.idx1-ubyte');  % load MNIST labels    
imagesTest =  loadMNISTImages('Select test image set','t10k-images.idx3-ubyte'); % load MNIST images
labelsTest =  loadMNISTLabels('Select test label set','t10k-labels.idx1-ubyte');  % load MNIST labels    
% check first 25 images visually
f = figure(1);
colormap(gray)                                  % set to grayscale
for i = 1:25                                    % preview first 25 samples
    subplot(6,5,i)                              
    digit = imagesTrain(:,:,i);                
    imagesc(digit)                              % show the image
    title(num2str(labelsTrain(i, 1)))           % show the label
end
subplot(6,5,26)
text(1,0.5,'Verify training images against labels','FontSize',14); axis off%

%%  Assign training and test data
Xtrain(:,:,1,:) = imagesTrain;% input for training
Ytrain = labelsTrain;         % target for training
Xtest(:,:,1,:) = imagesTest;  % input for test
Ytest = labelsTest;           % target for testing

%% CNN architecture
rng(1);   
layers = [
    imageInputLayer([28 28 1])          %MNIST image size
    convolution2dLayer(3,32,'Padding',1)
    batchNormalizationLayer
    reluLayer
    
    maxPooling2dLayer(2,'Stride',2)
    
    convolution2dLayer(3,32,'Padding',1)
    batchNormalizationLayer
    reluLayer
    
    maxPooling2dLayer(2,'Stride',2)
    
    convolution2dLayer(3,64,'Padding',1)
    batchNormalizationLayer
    reluLayer
  
    convolution2dLayer(3,64,'Padding',1)
    batchNormalizationLayer
    reluLayer
    
    maxPooling2dLayer(2,'Stride',2)
    
    fullyConnectedLayer(10)
    softmaxLayer
    classificationLayer];

%% training options. Test data only used for validation 
% and not for updating weights

options = trainingOptions('sgdm', ...
    'MaxEpochs',4, ...
    'ValidationData',{Xtest,categorical(Ytest)}, ...
    'ValidationFrequency',30, ...
    'Verbose',false, ...
    'Plots','training-progress');

%% training the CNN with training data
cnnNet = trainNetwork(Xtrain,categorical(Ytrain),layers,options);

YPredTrain = classify(cnnNet,Xtrain);
accuracyTrain = sum(YPredTrain == categorical(Ytrain))/numel(Ytrain);

YPredTest = classify(cnnNet,Xtest);
accuracyTest = sum(YPredTest == categorical(Ytest))/numel(Ytest);
close(f)
save('cnnNet.mat','cnnNet');
end



function labels = loadMNISTLabels(message,defaultChoice)
clc
[FileName,PathName] = uigetfile('*.idx1-ubyte',message,defaultChoice);
filename = [PathName FileName]; 
fp = fopen(filename, 'rb');
assert(fp ~= -1, ['Could not open ', filename, '']);
magic = fread(fp, 1, 'int32', 0, 'ieee-be');
assert(magic == 2049, ['Bad magic number in ', filename, '']);
numLabels = fread(fp, 1, 'int32', 0, 'ieee-be');
labels = fread(fp, inf, 'unsigned char');
assert(size(labels,1) == numLabels, 'Mismatch in label count');
fclose(fp);
end

function images = loadMNISTImages(message,defaultChoice)
clc
[FileName,PathName] = uigetfile('*.idx3-ubyte',message,defaultChoice);
filename = [PathName FileName]; 
fp = fopen(filename, 'rb');
assert(fp ~= -1, ['Could not open ', filename, '']);
magic = fread(fp, 1, 'int32', 0, 'ieee-be');
assert(magic == 2051, ['Bad magic number in ', filename, '']);
numImages = fread(fp, 1, 'int32', 0, 'ieee-be');
numRows = fread(fp, 1, 'int32', 0, 'ieee-be');
numCols = fread(fp, 1, 'int32', 0, 'ieee-be');
images = fread(fp, inf, 'unsigned char');
images = reshape(images, numCols, numRows, numImages);
images = permute(images,[2 1 3]);
fclose(fp);
%images = reshape(images, size(images, 1) * size(images, 2), size(images, 3));
images = double(images) / 255;
end