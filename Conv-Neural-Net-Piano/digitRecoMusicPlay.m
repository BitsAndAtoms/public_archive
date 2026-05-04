clc
clear all
close all;

% load pre trained network from CNN code
currentFolder = cd;
fileExisting  = (exist(fullfile(currentFolder, 'cnnNet.mat'), 'file') == 2);
%% run only if net is not already saved and trained

if fileExisting  %else throws error
load cnnNet;
% for entering image acquisition
isValid = true;
% choose live demo (for class) or test (file upload)
quest = 'Choose run mode';
answerOption = questdlg(quest,'Digit based music',...
                  'Live Demo','Via Upload','Quit','Quit');
if strcmp(answerOption,'Quit')
    isValid = false;
end
 % this is the static IP 
url = 'http://10.161.17.68:8080/shot.jpg'; %smartphone
camera = webcam; % PC 


 while isValid
     %% image display and thresholding
     pause(1)   % allows for network latency
     if strcmp(answerOption,'Live Demo')
     im1 = rgb2gray(snapshot(camera));       % Take a picture fropm computer
     %im1 = rgb2gray(imread(url));       % Take a picture from smartphone
     end
     
     if strcmp(answerOption,'Via Upload')
     [FileName,PathName] = uigetfile('*.jpg','Select image file');
     filename = [PathName FileName];
     im1 = rgb2gray(imread(filename));       % Take a picture from smartphone
     isValid = false;
     end
     
     makeBinary = @(im) imbinarize(im.data,median(double(im.data(:)))/1.2/255); % binarize with based on median value of image
     im = ~blockproc(im1,[50 50],makeBinary); 
     im = bwareaopen(im,20);      %delete noise less than 20
     %f = imshow(imoverlay(im1,im, [1 0.4 0.6]));
      
     
      %% detect ROI as maximum bouding box and objcts within
     objectRegion = regionprops(im,'Area','BoundingBox','PixelList','Centroid');
     coords = vertcat(objectRegion.Centroid);  % 2-by-18 matrix of centroid data
     if ~isempty(coords) 
     [~, sortIndex] = sortrows(coords, [2 1]);  % Sort by "y" ascending, then "x" ascending
     objectRegion = objectRegion(sortIndex);  % Apply sort index to s
     end
     numberOfRegions = numel(objectRegion);
     f = imshow(im1);
     hold on
if numberOfRegions ~=0
      maximumArea = 0;
      for k = 1:numberOfRegions
          A(k) = prod(objectRegion(k).BoundingBox(3:4));
         if objectRegion(k).Area > maximumArea
              maximumArea = objectRegion(k).Area;
             kmax = k;
         end
      end

      
      %% Plot bounding box if area of maximum bound is > 400 pixels
if maximumArea > 20^2
    diagonal1 = sum(objectRegion(kmax).PixelList,2);
    diagonal2 = diff(objectRegion(kmax).PixelList,[],2);
    [m,dUL] = min(diagonal1);    [m,dDR] = max(diagonal1);
    [m,dDL] = min(diagonal2);    [m,dUR] = max(diagonal2);
    pts = objectRegion(kmax).PixelList([dUL dDL dDR dUR dUL],:);
    h_pts = plot(pts(:,1),pts(:,2),'r','linewidth',3);

%% Identify objects inside bounding box with more than 100 pixels 
digitbox_minarea = 20^2; % Bounds for the digit bounding box area
clear imageClass Pnew 

% key for playing music
key = [];
% initialized center of bounding box for individual objects
centerPoint = zeros(numberOfRegions,2);
count = 1;
        for k = 1:numberOfRegions
            % objects are filtered based on min area and ~=  bounding box
            if A(k) > digitbox_minarea && A(k) ~= A(kmax)
                centerPoint(k,:) = [objectRegion(k).BoundingBox(1)+objectRegion(k).BoundingBox(3)/2 objectRegion(k).BoundingBox(2)+objectRegion(k).BoundingBox(4)/2];             
                % internal object precondition
                if inpolygon(centerPoint(k,1),centerPoint(k,2),pts(:,1),pts(:,2))
                dimIm = max(objectRegion(k).BoundingBox(3)/2+10,objectRegion(k).BoundingBox(4)/2+10);
                 % object must be away from edges   
                if ceil(centerPoint(k,2)+dimIm) <= size(im,1) && floor(centerPoint(k,2)-dimIm) >= 1 && ...
                    ceil(centerPoint(k,1)+dimIm) <= size(im,2) && floor(centerPoint(k,1)-dimIm) >= 1
                    imageClass{count} = imresize(im(floor(centerPoint(k,2)-dimIm):ceil(centerPoint(k,2)+dimIm),floor(centerPoint(k,1)-dimIm):ceil(centerPoint(k,1)+dimIm)),[28 28]); 
                    temp(:,:,1) = double(imageClass{count});
                    [label, err] = classify(cnnNet,temp); 
                        if err(double(label)) > 0.3
                        rectangle('Position', objectRegion(k).BoundingBox+3,'EdgeColor','r', 'LineWidth',1)
                        %txt1 = strcat('Digit: ',char(label),'  Accuracy: ',num2str(err(double(label)),'% 10.2f'));
                        txt1 = strcat(char(label));
                        % display digit at the top left corner
                        text(objectRegion(k).BoundingBox(1),objectRegion(k).BoundingBox(2),txt1,'Color','blue','FontSize',14)
                        key(count) = double(label)-1;
                        count = count+1; 
                        end
               end  
            end
          end
        end
        
        %play the piano keys starting from center C 
        if ~isempty(key)
        Fs=8000;
        Ts=1/Fs;
        t=0:Ts:1;  
        F_A = 440*((2)^(1/12)).^(key-9);
        A=sin(2*pi*F_A'*t);
        for i = 1:length(key)
            pause(1)
        sound(A(i,:),Fs);
        end
        end 
 end
 end
 hold off
 if ~ishandle(f)
     isValid = false;
 end
 end
else
   msgbox('Please first train CNN net by running code for CNN net', 'Error','error');
end
